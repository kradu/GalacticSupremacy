@include 'plugins/constants.lua'

common = compile("plugins/common.lua")

local db = c.CreateDatabase()
c.ConnectDatabase(db, DATABASE_TYPE_MYSQL, 
				  "127.0.0.1", "deco3800", "deco3800", "deco3800")

--Load handlers.
local handlers = compile("plugins/core/handlers.lua")

--[[
Optional:
Enable/Disable template caching (for debug purposes): 
	c.SetParamInt(WEBAPP_PARAM_TPLCACHE, 0)
Enable/Disable leveldb support (uses three threads, enabled by default): 
	c.SetParamInt(WEBAPP_PARAM_LEVELDB, 0)
Set the number of preferred threads (request handlers).
This value is negated by 3 if leveldb is enabled.
	c.SetParamInt(WEBAPP_PARAM_THREADS, 2)
	
--]]
c.SetParamInt(WEBAPP_PARAM_LEVELDB, 0)
--[[
Important:
Specify the size, in bytes, of the custom request struct allocated by
webapp for the VM.
]]
c.SetParamInt(WEBAPP_PARAM_REQUESTSIZE, ffi.sizeof("LuaRequest"))
