using UnityEngine;
using System.Collections;
using gsFramework;

public class MakeBuildings : MonoBehaviour {

	// should these be static? 
	public static int numBuildings = 3;
	public static Building[] buildings = new Building[numBuildings];

	// Use this for initialization
	void Start () {
		DefineHQ();
		DefineMine();
		DefineShipyard();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DefineHQ() {
		Building HQ = new Building();
		HQ.id = 0;
		HQ.name = "HeadQuarters";
		HQ.cost = 200;
		HQ.income = 10;
		HQ.constructionTime = 15f;

		buildings[0] = HQ;
	}

	void DefineMine() {
		Building Mine = new Building();
		Mine.id = 1;
		Mine.name = "Mine";
		Mine.cost = 100;
		Mine.income = 20;
		Mine.constructionTime = 10f;

		buildings[1] = Mine;
	}

	void DefineShipyard() {
		Building Shipyard = new Building();
		Shipyard.id = 2;
		Shipyard.name = "Shipyard";
		Shipyard.cost = 50;
		Shipyard.income = 0;
		Shipyard.constructionTime = 3f;

		buildings[2] = Shipyard;
	}
}
