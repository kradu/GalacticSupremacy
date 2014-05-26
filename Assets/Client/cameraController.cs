using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {
	int cameraVelocity = 1;
	public float camspeed;
	public GameObject player;
	private int pid;
	private Vector3 initPos;

	// Initialization
	void Start () {
		// determine which player is active
		player = GameObject.Find("Player");
		pid = player.GetComponent<PlayerState>().id;

		// set starting view to players start planet
		if (pid == 2) {
			initPos = new Vector3(16f, 20f, 16.5f);
		} else if (pid == 1) {
			initPos = new Vector3(-14.56f, 20f, -14.7f);
		}
		transform.localPosition = initPos;
	}
	
	// Update is called once per frame
	void Update () {
		// Left
		if((Input.GetKey(KeyCode.LeftArrow)))
		{
			transform.Translate((Vector3.left* cameraVelocity) * Time.deltaTime* camspeed);
		}
		// Right
		if((Input.GetKey(KeyCode.RightArrow)))
		{
			transform.Translate((Vector3.right * cameraVelocity) * Time.deltaTime* camspeed);
		}
		// Up
		if((Input.GetKey(KeyCode.UpArrow)))
		{
			transform.Translate((Vector3.up * cameraVelocity) * Time.deltaTime* camspeed);
		}
		// Down
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate((Vector3.down * cameraVelocity) * Time.deltaTime* camspeed);
		}
	}
}
