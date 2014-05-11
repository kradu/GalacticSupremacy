using UnityEngine;
using System.Collections;

public class solarRegion : MonoBehaviour {
	public Transform scout;
	public int SIZE;
	public bool isSelected = false;
	public GameObject createdScout;
	// Use this for initialization
	void Start () {
		int size = Random.Range (0, 3);
		SIZE = size;
		this.transform.localScale = new Vector3  (size, size, size);
		rigidbody.isKinematic = true;
		
		
	}
	void OnMouseOver() {
		if (isSelected == false) {
			renderer.material.color = new Color (1F, 1F, 0);
		}
	}
	
	void OnMouseExit(){
		if (isSelected == false) {
			renderer.material.color = new Color (1F, 1F, 1F);
		}
	}
	
	void OnMouseUp(){
		if (isSelected == false) {
			Vector3 myPosition = transform.position;
			float xPos = myPosition.x;
			float yPos = myPosition.y;
			float zPos = myPosition.z;
			createdScout = Instantiate (scout, new Vector3 (xPos + SIZE, yPos, zPos), Quaternion.identity) as GameObject;;
			isSelected = true;
		}
	}
	public void ChangeColour(Color colour){
		renderer.material.color = colour;
	}
	
	GameObject GetScout(){
		return createdScout;
	}
	// Update is called once per frame
	void Update () {
		
	}
	public void printID(){
	}
}
