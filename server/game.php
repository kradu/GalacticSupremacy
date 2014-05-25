<?php
define("IN_GAME", TRUE);
require("include/game_logic.php");

$ACTION_SEND_CHAT = 0;
$ACTION_GET_CHAT = 1;
$ACTION_GET_GAMESTATE = 2;
$ACTION_PLAYER_EVENT = 3;


$action = (int)$_POST['action'];
$request = json_decode(file_get_contents('php://input'), true);

switch($action) {
	case $ACTION_SEND_CHAT:
		return send_chat($request);
	case $ACTION_GET_CHAT:
		return get_chat($request);
	case $ACTION_GET_GAMESTATE:
		return get_gamestate($request);
	case $ACTION_PLAYER_EVENT:
		return player_event($request);
}

?>
