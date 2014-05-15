using UnityEngine;
using System.Collections;

public class scout : MonoBehaviour {

	public float moveSpeed = 0.1f;
	// Use this for initialization
	void Start () {
		//Setting size and colour of scout
		float size = .5f;
		this.transform.localScale = new Vector3  (size, size, size);
		renderer.material.color = new Color (1F, 0, 0);
		
		
	}
	void showUp(){
		
	}

	public void changeToBlue(){
		renderer.material.color = new Color (0F, 0F, 1F);
		}

	public void moveToLocation(Vector3 newPosition){
		//Used by mainController to move scout.
		transform.position = new Vector3(newPosition.x + 1F, newPosition.y, newPosition.z);
		}

	// Update is called once per frame
	void Update () {
	}
}