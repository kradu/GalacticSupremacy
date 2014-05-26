using UnityEngine;
using System.Collections;
using gsFramework;

public class MainGUI : MonoBehaviour {

	//public GUISkin mySkin;
	public SolReg selectedSR;

	Rect resourcePanel = new Rect(0, 0, 370, 50);
	Rect regionInfoPanel = new Rect(0, Screen.height-200, Screen.width, 250);
	// Rect mapPanel = new Rect(20, 210, 590, 250);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		resourcePanel = GUI.Window(0, resourcePanel, DrawResourcePanel, "Resources");
		regionInfoPanel = GUI.Window(1, regionInfoPanel, DrawRegionPanel, "Region Panel");

	}

	void DrawResourcePanel(int id) {
		GUI.Label(new Rect(20, 20, 120, 20 ),"Credits: $999");
		GUI.Label(new Rect(120, 20, 120, 20 ),"Income: $20/hr");
		GUI.Label(new Rect(220, 20, 120, 20 ),"Fleet Upkeep: 5/20");
	}

	void DrawRegionPanel(int id) {
		GUI.Label(new Rect(20, 20, 120, 20 ),"Region "+ selectedSR.id +" selected." );
	}

}
