using UnityEngine;
using System.Collections;

public class scout : MonoBehaviour {

	public float moveSpeed = 0.1f;
	// Use this for initialization
	void Start () {
		float size = .5f;
		this.transform.localScale = new Vector3  (size, size, size);
		renderer.material.color = new Color (1F, 0, 0);
		
		
	}
	void showUp(){
		
	}
	void OnMouseOver() {
		renderer.material.color = new Color (1F, 1F, 0);
	}
	
	void OnMouseExit(){
		renderer.material.color = new Color (1F, 1F, 1F);
	}
	// Update is called once per frame
	void Update () {
	}
}