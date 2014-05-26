using UnityEngine;
using System.Collections;
using gsFramework;

public class MainGUI : MonoBehaviour {

	//public GUISkin mySkin;
	public SolReg selectedSR;
	public GameObject Player;

	Rect resourcePanel = new Rect(0, 0, 370, 50);
	Rect regionInfoPanel = new Rect(0, Screen.height-200, Screen.width, 250);
	// Rect mapPanel = new Rect(20, 210, 590, 250);
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		resourcePanel = GUI.Window(0, resourcePanel, DrawResourcePanel, "Resources");
		regionInfoPanel = GUI.Window(1, regionInfoPanel, DrawRegionPanel, "Region "+ selectedSR.id);

	}

	void DrawResourcePanel(int id) {
		int credits = Player.GetComponent<PlayerState>().credits;
		int income = Player.GetComponent<PlayerState>().income;
		GUI.Label(new Rect(20, 20, 120, 20 ),"Credits: $"+ credits);
		GUI.Label(new Rect(120, 20, 120, 20 ),"Income: $"+ income +"/sec");
		GUI.Label(new Rect(220, 20, 120, 20 ),"Fleet Upkeep: 5/20");
	}

	void DrawRegionPanel(int id) {
		// SolReg Stats get displayed here:
		GUI.Label(new Rect(20, 20, 120, 20 ),"Region "+ selectedSR.id);
		GUI.Label(new Rect(20, 60, 120, 20 ),"Owned by Player "+ selectedSR.owner);
		GUI.Label(new Rect(20, 100, 120, 20 ),"Income: "+ selectedSR.income);
		GUI.Label(new Rect(20, 140, 120, 20 ),"Construction Slots:"+ selectedSR.slots);

		//for (int i = 0; i < 6; ++i) {
		// grid layout variables
		int boxXY = 70;
		int xStart = 200;
		int yStart = 120;
		for (int i = 1; i < (selectedSR.slots+1); ++i) {
			GUI.Box(new Rect(xStart+(i*70), yStart, boxXY, boxXY),"Empty");
		}
	}
		
}
