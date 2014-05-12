using UnityEngine;
using System.Collections;

public class mainController : MonoBehaviour {
	int seed = 10;
	
	int count = 0;
	public GameObject solarRegion;
	public static bool systemIsSelected = false;
	public static bool destinationIsSelected = false;
	static bool scoutHasMoved = false;
	public static solarRegion selectedSolarRegion;
	public static solarRegion destinationSolarRegion;
	public static GameObject scoutToMove;
	public scout scoutToMoveScript;
	// Use this for initialization
	void Start () {
		for(int i = 0; i <= 10; i++) {
			
			int size = Random.Range (0, 3);
			solarRegion solarRegionScript;
			GameObject solarRegionClone;
			//GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			solarRegionClone = Instantiate(solarRegion, new Vector3 (Random.Range (0, 10), 0, Random.Range (0, 10)), Quaternion.identity) as GameObject;
			solarRegionScript = solarRegionClone.gameObject.GetComponent<solarRegion>();
			solarRegionScript.printID();
			//solarRegionScript.ChangeColour(new Color (1F, 1F, 0F));
			count++;
		}
		//system createdSystem = Instantiate(system, new Vector3 (Random.Range (0, 10), 0, Random.Range (0, 10)), Quaternion.identity) as system;
		//createdSystem.ChangeColour(new Color(1F, 0, 1F));
	}

	
	// Update is called once per frame
	void Update () {
		if (destinationIsSelected == true) {
			destinationSolarRegion.ChangeColour (new Color(0F, 1F, 0F));
			if(scoutHasMoved == false){
				scoutHasMoved = true;
				print (scoutToMove.transform.position);
				scoutToMoveScript = scoutToMove.gameObject.GetComponent<scout>();
				scoutToMoveScript.moveToLocation (destinationSolarRegion.getLocation());
				scoutHasMoved = true;
				print ("scout has moved to " + destinationSolarRegion.getLocation().ToString());

			}
				}
	}
}
