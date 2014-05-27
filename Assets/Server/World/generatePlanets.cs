using UnityEngine;
using System.Collections;
using gsFramework;

public class generatePlanets : MonoBehaviour {

	/********** Struct Definitions **********/
	

	private float dimensions = 20.0f;
	public static int numRegions = 10;	// The number of SolReg in the sector.
	
	// should this be static? 
	public static SolReg[] regions = new SolReg[numRegions];



	/*
	Region Coordinates: 
	15.6, 2.9
	1.9, -8.5
	-8.2, -4.9
	9.5, -6.7
	-0.3, -1.24
	-4, -14.3
	start 16, 16.5
	9.6, 14.36
	6.6, 3.92
	start -14.56, -14.7
	*/
	private float[] xPos = new float[10] {15.6f, 1.9f, -8.2f, 9.5f, -0.3f, -4.0f, 16.0f, 9.6f, 6.6f, -14.56f};
	private float[] zPos = new float[10] {2.9f, -8.5f, -4.9f, -6.7f, -1.24f, -14.3f, 16.5f, 14.36f, 3.92f, -14.7f};

	//private Vector3 pos;

	// "Server" startup; Initialisation
	void Start () {
		// draw map borders
		draw_borders();

		// Generate attributes of the regions
		for (int i = 0; i < numRegions; ++i) {
			regions[i].id = i+1;

			regions[i].x = xPos[i];
			regions[i].z = zPos[i];
			regions[i].owner = 0;

			regions[i].scale = Random.Range(0.1f, 1.0f);
			regions[i].texture = "texture" + Random.Range(1, 4);

			regions[i].income = Random.Range(20, 50);
			regions[i].slots = Random.Range(3, 6);
			regions[i].emptySlots = regions[i].slots;
			regions[i].buildings = new Building[regions[i].slots];
		}
		InitOwnership();
		connect_regions();
	}
	

	private void connect_regions() {
		for (int i = 0; i < numRegions; ++i) {
			
		}
	}

	private void InitOwnership() {
		regions[6].owner = 2;
		regions[9].owner = 1;
	}

	
	

	/* 
	 * calc_distance takes 2 vectors as inputs and calculates the
	 * straight-line distance using the pythagorean theorem.
	 */
	private float calc_distance(Vector3 point1, Vector3 point2) {
		float distance;
		//float distanceX = Mathf.Abs(point1.x - point2.x);
		//float distanceZ = Mathf.Abs(point1.z - point2.z);

		//distance = Mathf.Sqrt(Mathf.Pow(distanceX, 2.00) + Mathf.Pow(distanceZ, 2.00));
		distance = Vector3.Distance(point1, point2);

		return distance;
	}


	public static int get_region_num () {
		int num = numRegions;
		return num;
	}
	
	/*
	 * getRegions allows a client to retrieve a sectors regions and their attributes.
	 */
	public static SolReg get_sol_reg (int index) {
		SolReg reg = regions[index];
		//print("index: " + index);
		//print("id: " + regions[index].id);
		return reg;
	}

	/*
	 * draw_borders simply places a cube on each corner of the map.
	 */
	private void draw_borders() {
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.localPosition = new Vector3(-dimensions, 0, -dimensions);
		GameObject cube2 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube2.transform.localPosition = new Vector3(dimensions, 0, dimensions);
		GameObject cube3 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube3.transform.localPosition = new Vector3(-dimensions, 0, dimensions);
		GameObject cube4 = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube4.transform.localPosition = new Vector3(dimensions, 0, -dimensions);
	}
	




	private Vector3 find_new_pos(int index) {
	 	float colDist = 2.0f;
	 	float minDist = colDist;
	 	float distance;
	 	Vector3 newPos= new Vector3(0, 0, 0);
	 	bool hasCollision = true;
	 	Vector3 otherPos;
	 	

	 	float randX, xDist;


	 	// while (something) {
	 		randX = Random.Range(-dimensions, dimensions);

	 		for (int i = 0; i < index; ++i) {
	 			xDist = Mathf.Abs(randX-regions[i].x);
	 		}
	 	//}


	 	//while (hasCollision == true) {
		 	//newPos = new Vector3(Random.Range(-dimensions, dimensions), 0, Random.Range(-dimensions, dimensions));
		 	
		 	
		 	
		 	/*
		 	for (int i = 0; i < index; ++i) {
		 		otherPos = new Vector3(regions[i].x, 0, regions[i].z);
		 		distance = Vector3.Distance(newPos, otherPos);
		 		
		 		minDist = Mathf.Min(distance, minDist);
		 		print((index+1) + " distance to " + (i+1) + ": " + distance + " | min: " + minDist);
		 	}
		 	if (minDist < colDist) {
		 		print((index+1) + " is in collision!");
		 		hasCollision = true;
		 	} else {
		 		hasCollision = false;
		 	} */
	 	//}
		

		return newPos;
	 }

}


