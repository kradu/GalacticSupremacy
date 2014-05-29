<?php
require("db.php");
function send_chat($request) {
	
}

function get_chat($request) {

}


$gamestate = array(
	20, //dimensions
	//store each planet
	array(
		//sector id, planet id, xpos, zpos, scale, texture, owner, income, slots, array(connections)
		array(0,0,15.6,2.9,0.5,1,0,10,3,array(1, 2)),
		array(0,1,1.9,-8.5,0.2,4,0,14,2,array(0, 3)),
		array(0,2,-8.2,-4.9,0.6,2,0,18,4,array(0)),
		array(0,3,9.5,-6.7,0.1,3,0,4,3,array(1)),
		array(0,4,-0.3,-1.24,0.3,3,0,7,5,array(5)),
		array(0,5,-4,-14.3,0.7,1,0,24,7,array(6, 4)),
		array(0,6,16,16.5,0.8,4,0,14,1,array(7, 5)),
		array(0,7,9.6,14.36,0.8,3,0,29,2,array(8, 6)),
		array(0,8,6.6,3.92,0.4,3,0,3,2,array(9, 7)),
		array(0,9,-14.56,-14.7,0.5,1,0,11,4,array(8))
	)
);

/*
Return the game-state to the player. 
This should be called every frame.
*/

function get_gamestate($request) {
	echo json_encode($gamestate);
}

function player_event($request) {
	
}

?>
