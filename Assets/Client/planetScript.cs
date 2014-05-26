using UnityEngine;
using System.Collections;
using gsFramework;
/*
 * Discuss:
 *	- does the region have to know it is selected/deselected? handled in client.
 */

public class planetScript : MonoBehaviour {
	public Shader shDefault = Shader.Find("Diffuse");
	public Shader shSelected = Shader.Find("Self-Illumin/Diffuse");

	public GameObject startup;
	public float smooth;
	private Vector3 newScale;
	private bool MouseOver;
	//private bool isSelected;
	private bool debug;
	public SolReg thisSR;
	GameObject ownIndic;

	// Use this for initialization
	void Awake() {
		newScale = transform.localScale;
		//isSelected = false;
		smooth = 5;
		debug = true;
		startup = GameObject.Find("startup");
	}

	// Use this for initialization
	void Start() {
		SetOwner();
	}
	
	/* Update is called once per frame:
	 * - gives rotation to the solarRegion
	 * - scales solarRegions onMouseOver
	 */
	void Update() {
		// Visual: Adds rotation to the solarRegion.
		this.transform.Rotate(Vector3.forward * Time.deltaTime*10, Space.World);

		// Visual: Increases scale on MouseOver:
		ScaleChanging();
	}

	void SetOwner() {
		ownIndic = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		ownIndic.transform.localPosition = this.transform.localPosition;
		//ownIndic.transform.localPosition.y -=1;
		ownIndic.transform.localScale = new Vector3(1.8f, 0, 1.8f);

		SphereCollider myCollider = ownIndic.transform.GetComponent<SphereCollider>();
		myCollider.radius = 0f; // or whatever radius you want.

		if (thisSR.owner == 0) {
			ownIndic.renderer.material.color = Color.grey;
		} else if (thisSR.owner == 1) {
			ownIndic.renderer.material.color = Color.blue;
		} else if (thisSR.owner == 2) {
			ownIndic.renderer.material.color = Color.red;
		}

		//ownIndic.renderer.material.color.a = 0.2f;
	}

	void ScaleChanging() {
		Vector3 scaleA = new Vector3 (1, 1, 1);
		Vector3 scaleB = new Vector3 (2, 2, 2);

		if (MouseOver) {
			newScale = scaleB;
		} else {
			newScale = scaleA;
		}
		
		this.transform.localScale = Vector3.Lerp(this.transform.localScale, newScale, smooth * Time.deltaTime);
	}

	void OnMouseUp () {
		Select();
		if (debug) {
			//print("PLANET: selection made.");
		}
	}

	public void Deselect() {
		// do i need this method?...
		ownIndic.transform.localScale = new Vector3(1.8f, 0, 1.8f);
		ownIndic.renderer.material.shader = shDefault;
	}

	void Select() {
		// Tell client this region was selected:
		startup.GetComponent<startup>().SelectSR(thisSR);
		ownIndic.transform.localScale = new Vector3(2.2f, 0, 2.2f);
		ownIndic.renderer.material.shader = shSelected;

	}


/*********************** Helper Functions  ***********************/
	void OnMouseEnter() {
		MouseOver = true;	
		if (debug) {
			//print("PLANET: entering object");
			print("PLANET: ID: "+thisSR.id+" owner: "+thisSR.owner);
		}
	}

	void OnMouseExit() {
		MouseOver = false;
		
		if (debug) {
			//print("PLANET: leaving object");
		}
	}

	public void SetSR(SolReg region) {
		thisSR = region;
	}
}