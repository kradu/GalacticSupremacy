-- core/process.lua
-- Main instance handling/request processing script.
@include 'plugins/constants.lua'

--handlers: Function handlers for API calls.
common = compile("plugins/common.lua")

--asynchronous event table. Used to enable concurrent 
local events = common.new_table(NUM_EVENTS, 0)

local time = require "time"
local mp = require "MessagePack"

--The global (current) request object.
request = nil
--The lua request object.
r = nil

local function cursor_string (str)
	return {
		s = str,
		i = 1,
		j = #str,
		underflow = function (self)
						error "missing bytes"
					end,
	}
end

function unpacker(src)
	local cursor = cursor_string(src)
	return function ()
		if cursor.i <= cursor.j then
			local ret = mp.unpackers.any(cursor)
			return cursor.i, ret
		end
	end
end

local function get_buffer(u)
	local i, ret = u()
	if type(ret) ~= "string" then
		return nil, 0
	end
	local l = ret:len()
	return request.headers_buf.data + i - l - 1, l
end

function hashPassword(password, salt)
	local pass --hashed password.
	--Process password, salt.
	if password ~= nil and string.len(password) > 0 then
		if salt == nil then
			salt = ""
			for i = 1,6 do
				salt = salt .. string.char(math.random(32, 126))
			end
		end
		pass = common.tohex(sha2.sha256(password .. salt))
	end
	return pass, salt
end

function login(user, pass, session)
	local query = c.CreateQuery(common.cstr(SELECT_USER_LOGIN), request, db, 0)
	c.BindParameter(query, common.cstr(user))
	local res = c.SelectQuery(query) 
	
	if res == DATABASE_QUERY_STARTED 
		and query.column_count == @icol(COLS_USER) then
		local user = query.row
		local userid = tonumber(common.appstr(user[0]))
		--Check password.
		local salt = common.appstr(COL_USER("salt"))
		local storedpw = common.appstr(COL_USER("pass"))
		local hashedpw = ""
		if pass ~= nil then hashedpw = hashPassword(password, salt) end
		if userid ~= nil and userid > 0 and hashedpw == storedpw then	
			return 1
		else
			return 0
		end
	else
		return 0
	end
end

function handle_request()
	local request_buf = common.appstr(request.headers_buf)
	local u = unpacker(request_buf)
	local _, command = u()
	
	if command == 0 then --LOGIN
		local user = ffi.string(get_buffer(u))
		local pass = ffi.string(get_buffer(u))
		login(user, pass)
	end
	
	return "\x01\x01"
end

function start_request()
	local ret, response = pcall(handle_request)
	if not ret then
		if response then io.write(response) end
		local empty = ""
	end
	c.WriteData(request.socket, common.cstr(response))
	return 1
end

function run_coroutine(f)
	while f do 
		f = coroutine.yield(f()) 
	end
end

local ev = coroutine.create(run_coroutine)
--use event_ctr to 'round-robin' events, to speed up empty event finding
local event_ctr = 1

request = c.GetNextRequest(worker)
while request ~= nil do
	r = request.r
	print(request)
	local co = tonumber(r.co)
	if co > 0 then
		ev = events[co]
	end
	local ret
	_, ret = coroutine.resume(ev, start_request)

	--co may have changed, indicating a yield.
	if ret ~= 1 then
		--ret not 1, must have yielded before end of start_request.
		--Store the coroutine for later.
		--find an empty slot
		local target_ev = 0
		local num_events = #events
		--Simple (round robin) search algorithm. Search from event_ctr->end
		for i = event_ctr, num_events do
			if events[i] == nil then
				target_ev = i
				break
			end
		end
		
		if target_ev == 0 then
			--Search from 1->event_ctr.
			for i = 1, event_ctr do
				if events[i] == nil then
					target_ev = i
					break
				end
			end
		end
		
		--Still no free event found? Then just place at end of table.
		if target_ev == 0 then
			target_ev = num_events
		end
		
		events[target_ev] = ev
		--Provide a way for the request to resume the coroutine.
		r.co = target_ev
		--clear base event for next loop.
		ev = coroutine.create(run_coroutine)
		event_ctr = target_ev + 1
		--Reset event_ctr when it reaches the max value.
		if event_ctr > NUM_EVENTS then
			event_ctr = 1
		end
	else
		--event has finished. Ensure we clear out the old coroutine.
		if co > 0 then events[co] = nil end
		--Clean up the request
		c.FinishRequest(request)
	end
	request = c.GetNextRequest(worker)
end
