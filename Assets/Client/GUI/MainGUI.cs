using UnityEngine;
using System.Collections;
using gsFramework;

public class MainGUI : MonoBehaviour {

	//public GUISkin mySkin;
	public SolReg selectedSR;
	public GameObject Player;
	public GameObject Server;
	public bool showConMenu = false;
	private int buttonClicked;
	//public MakeBuildings buildingServ;
	public Building[] buildings;
	public int numBuildings;

	Rect resourcePanel = new Rect(0, 0, 370, 50);
	Rect regionInfoPanel = new Rect(0, Screen.height-200, Screen.width, 250);
	Rect constructionPanel = new Rect(Screen.width/3, Screen.height/5, 250, 250);
	
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
		Server = GameObject.Find("Server");

		numBuildings = MakeBuildings.numBuildings;
		//buildings = new Building[numBuildings];

		//for (int i = 0; i < numBuildings; ++i) {
			// This would be a server request:
			//buildings[i] = MakeBuildings.buildings[i];
			//DrawRegion(regions[i]);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI () {
		resourcePanel = GUI.Window(0, resourcePanel, DrawResourcePanel, "Resources");
		regionInfoPanel = GUI.Window(1, regionInfoPanel, DrawRegionPanel, "Region "+ selectedSR.id);

		if (showConMenu) {
			constructionPanel = GUI.Window(2, constructionPanel, DrawConPanel, "Construction Menu");
		}
	}

	void DrawResourcePanel(int id) {
		int credits = Player.GetComponent<PlayerState>().credits;
		int income = Player.GetComponent<PlayerState>().income;
		GUI.Label(new Rect(20, 20, 120, 20 ), "Credits: $"+ credits);
		GUI.Label(new Rect(120, 20, 120, 20 ),"Income: $"+ income +"/sec");
		GUI.Label(new Rect(220, 20, 120, 20 ),"Fleet Upkeep: 5/20");
	}

	/*	This function draws the panel at the bottom of the screen which shows
	 *	information on the currently selected region, and interaction options
	 * 	available to the player.
	 */
	void DrawRegionPanel(int id) {
		// SolReg Stats get displayed in the far left:
		GUI.Label(new Rect(20, 20, 130, 20 ), "Region "+ selectedSR.id +" debug data");
		GUI.Label(new Rect(20, 55, 130, 20 ), "Owned by Player "+ selectedSR.owner);
		GUI.Label(new Rect(20, 90, 130, 20 ), "Income: "+ selectedSR.income);
		GUI.Label(new Rect(20, 125, 130, 20 ),"Construction Slots: "+ selectedSR.slots);
		GUI.Label(new Rect(20, 160, 130, 20 ),"Empty Slots: "+ selectedSR.emptySlots);

	
		//Grid layout variables
		int boxXY = 70;
		int xStart = 200;
		int yStart = 120;
		for (int i = 0; i < selectedSR.slots; ++i) {
			
			if (selectedSR.buildings[i].cost == 0) {
				if (GUI.Button(new Rect(xStart+(i*70), yStart, boxXY, boxXY), "Empty\nSlot")) {
					showConMenu = true;
					buttonClicked = i;
				}
			} else {
				if (GUI.Button(new Rect(xStart+(i*70), yStart, boxXY, boxXY), selectedSR.buildings[i].name)) {
					//showConMenu = true;
					//buttonClicked = i;
				}
			}
		}
	}

	void DrawConPanel(int id) {

		for (int i = 0; i < numBuildings; ++i) {
			if (GUI.Button(new Rect(20, 20+(i*25), 100, 20), "Build" +MakeBuildings.buildings[i].name)) {
				Build(i);
			}	
		}

		if (GUI.Button(new Rect(150, 200, 60, 20), "Close")) {
				showConMenu = false;
			}
	}


	void Build (int id) {

		// check if enough resources are available
		int available = Player.GetComponent<PlayerState>().credits;
		int cost = MakeBuildings.buildings[id].cost;
		print("MainGUI: "+MakeBuildings.buildings[id].name+" Cost: $"+cost);


		if (available >= cost) {	// sufficient funds are available
			// Inform server of the incurred cost
			Player.GetComponent<PlayerState>().credits -= cost;
			
			// Add building to the region
			int idSR = selectedSR.id;
			selectedSR.buildings[buttonClicked] = MakeBuildings.buildings[id];

			// update SR @ serverside, should be some request
			generatePlanets.regions[idSR-1].buildings[buttonClicked]=MakeBuildings.buildings[id];

			// Finally, hide menu again
			showConMenu = false;	
		} else {
			// not enough funds, inform player
			// TODO
		}
	}
		
}
