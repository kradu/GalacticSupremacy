using UnityEngine;
using System.Collections;

public class LoginGUI : MonoBehaviour {
	public GameObject player;	// linked to the playerobject


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// creates a simple GUI with 2 buttons. button press will assign the player an id and start
	// the next scene.
	void OnGUI () {
		GUI.Box(new Rect(10,10,100,90), "Loader Menu");
	

	// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Player Blue")) {
			player.GetComponent<PlayerState>().id = 1;
			Application.LoadLevel("scene1");
		}

		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Player Red")) {
			player.GetComponent<PlayerState>().id = 2;
			Application.LoadLevel("scene1");
		}
	}
}
