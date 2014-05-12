using UnityEngine;
using System.Collections;

public class mainController : MonoBehaviour {
	int seed = 10;
	
	int count = 0;
	//GameObjects
	public GameObject solarRegion;
	public scout scoutToMoveScript;
	public static GameObject scoutToMove;
	//Boolean flags
	public static bool systemIsSelected = false;
	public static bool destinationIsSelected = false;
	public static bool scoutHasMoved = false;
	//Solar regions between which the scout moves
	public static solarRegion selectedSolarRegion;
	public static solarRegion destinationSolarRegion;
	// Use this for initialization
	void Start () {
		//Sets out rows
		for (int i = 0; i < 3; i++) {
			//Sets out columns
						for (int j = 0; j<4; j++) {
				//Solar regions which are instantiated
				solarRegion solarRegionScript;
				GameObject solarRegionClone;
				//Sets the spacing of the random locations so that there isn't overlap
				int spacingInt = 4;
				//Making the solar regions
				solarRegionClone = Instantiate (solarRegion, new Vector3 (Random.Range (i*spacingInt, (i*spacingInt)+(spacingInt-1)), 0, Random.Range (j*spacingInt, (j*spacingInt)+(spacingInt-1))), Quaternion.identity) as GameObject;
				//Getting access to the functions of the Solar region
				solarRegionScript = solarRegionClone.gameObject.GetComponent<solarRegion> ();
						}
				}
	}

	
	// Update is called once per frame
	void Update () {
		//Checking if there has been a destination selected for the scout to move to (should put this
		//whole thing as function in scout class)
		if (destinationIsSelected == true) {
			//For debug purposes
			destinationSolarRegion.ChangeColour (new Color(0F, 1F, 0F));
			//Checking that the scout hasn't already moved
			if(scoutHasMoved == false){
				//Accessing the functions of the scout in question
				scoutToMoveScript = scoutToMove.gameObject.GetComponent<scout>();
				//Sending the scout to the new solar region
				scoutToMoveScript.moveToLocation (destinationSolarRegion.getLocation());
				//Resetting the boolean
				scoutHasMoved = true;
			}
				}
	}
}
