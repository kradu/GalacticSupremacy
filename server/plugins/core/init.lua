@include 'plugins/constants.lua'
common = compile("plugins/common.lua")

local db = c.Database_Create()
c.Database_Connect(db, DATABASE_TYPE_MYSQL,
				  "127.0.0.1", "deco3800", "deco3800", "deco3800")

c.Database_Exec(db, common.cstr(SQL_SESSION(db.db_type)))
for k,v in ipairs(APP_SCHEMA) do
	for i, j in ipairs(common.split(v, ";")) do
		c.Database_Exec(db, common.cstr(j))
	end
end

--[[
Optional:
Enable/Disable template caching (for debug purposes): 
	c.Param_Set(SERVER_PARAM_TPLCACHE, 0)
Enable/Disable leveldb support (uses three threads, enabled by default): 
	c.Param_Set(SERVER_PARAM_LEVELDB, 0)
Set the number of preferred threads (request handlers).
This value is negated by 3 if leveldb is enabled.
	c.Param_Set(SERVER_PARAM_THREADS, 2)
	
--]]
c.Param_Set(SERVER_PARAM_LEVELDB, 0)
--[[
Important:
Specify the size, in bytes, of the custom request struct allocated by
webapp for the VM.
]]
c.Param_Set(SERVER_PARAM_REQUESTSIZE, ffi.sizeof("LuaRequest"))
