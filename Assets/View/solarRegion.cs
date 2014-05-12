using UnityEngine;
using System.Collections;

public class solarRegion : MonoBehaviour {
	public GameObject scout;
	public int SIZE;


	// Use this for initialization
	void Start () {
		int size = Random.Range (0, 3);
		SIZE = size;
		this.transform.localScale = new Vector3  (size, size, size);
		rigidbody.isKinematic = true;
		
		
	}
	void OnMouseOver() {
		if (mainController.systemIsSelected == false) {
			renderer.material.color = new Color (1F, 1F, 0);
		}
	}
	
	void OnMouseExit(){
		if (mainController.systemIsSelected == false) {
			renderer.material.color = new Color (1F, 1F, 1F);
		}
	}
	
	void OnMouseUp(){
		if (mainController.systemIsSelected == false) {
			scout createdScoutScript;
			GameObject createdScout;

			Vector3 myPosition = transform.position;
			float xPos = myPosition.x;
			float yPos = myPosition.y;
			float zPos = myPosition.z;
			createdScout = Instantiate (scout, new Vector3 (xPos + SIZE, yPos, zPos), Quaternion.identity) as GameObject;


			mainController.systemIsSelected = true;
			mainController.selectedSolarRegion = this.gameObject.GetComponent<solarRegion> ();
			mainController.scoutToMove = createdScout;

			//mainController.scoutToMove.changeToBlue ();
		} else {
			mainController.destinationSolarRegion = this;
			mainController.destinationIsSelected = true;
		}
	}
	public void ChangeColour(Color colour){
		renderer.material.color = colour;
	}

	public Vector3 getLocation(){
		return transform.position;
		}
	

	// Update is called once per frame
	void Update () {
		
	}
	public void printID(){
	}
}
