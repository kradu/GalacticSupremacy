using UnityEngine;
using System.Collections;

public class solarRegion : MonoBehaviour {
	public GameObject scout;
	public int SIZE;


	// Use this for initialization
	void Start () {
		//Making the sizes different so that it looks cooler
		int size = Random.Range (1, 3);
		this.transform.localScale = new Vector3  (size, size, size);
		//So that it's not affected by gravity
		rigidbody.isKinematic = true;
		
		
	}
	void OnMouseOver() {
		if (mainController.systemIsSelected == false) {
			//Highlighting on hover
			renderer.material.color = new Color (1F, 1F, 0);
		}
	}
	
	void OnMouseExit(){
		if (mainController.systemIsSelected == false) {
			//Resetting to normal colour after hover
			renderer.material.color = new Color (1F, 1F, 1F);
		}
	}
	
	void OnMouseUp(){
		//This is the orignal solar region being selected
		if (mainController.systemIsSelected == false) {
			//Setting up variables
			scout createdScoutScript;
			GameObject createdScout;

			//Breaking down the position of the solar region to place the scout beside it.
			Vector3 myPosition = transform.position;
			float xPos = myPosition.x;
			float yPos = myPosition.y;
			float zPos = myPosition.z;

			//Instantiate the scout with the location of beside the solar region
			createdScout = Instantiate (scout, new Vector3 (xPos + SIZE, yPos, zPos), Quaternion.identity) as GameObject;
			//Make sure that mainController knows that a system has been selected
			mainController.systemIsSelected = true;
			//Accesses the functions of this solar region so that they can be used in mainController
			mainController.selectedSolarRegion = this.gameObject.GetComponent<solarRegion> ();
			//Giving the created scout to the mainController
			mainController.scoutToMove = createdScout;
		} 
		//This is the destination solar region being selected
		else {
			//Gives the mainController this solar region
			mainController.destinationSolarRegion = this;
			//Sets booleans appropriately
			mainController.destinationIsSelected = true;
			mainController.scoutHasMoved = false;
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
