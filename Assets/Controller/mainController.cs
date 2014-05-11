using UnityEngine;
using System.Collections;

public class mainController : MonoBehaviour {
	int seed = 10;
	
	int count = 0;
	public GameObject solarRegion;
	// Use this for initialization
	void Start () {
		for(int i = 0; i <= 10; i++) {
			
			int size = Random.Range (0, 3);
			//GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			GameObject solarRegionClone = Instantiate(solarRegion, new Vector3 (Random.Range (0, 10), 0, Random.Range (0, 10)), Quaternion.identity) as GameObject;
			//systemComponent = system.GetComponent(systemScript);
			//sphere.renderer.material.color = new Color(Random.Range (0, 1), Random.Range (0, 1), Random.Range (0, 1));
			//GameObject systemClone1 = GameObject.Find("systemClone");
			//this.GetComponent<system>().ChangeColour (Color(0.1, 0.1, 0.1, 1));
			//nextNameNumber++;
			
			
			//systemScript.GetComponent<system>();
			//systemScript.name = "system"+nextNameNumber;
			
			// You can also acccess other components / scripts of the clone
			
			//				var gameBoardPrefab : GameObject;
			//			static var gameBoard : GameObject;
			//			static var gBcomponent : gameBoardScript;
			//			
			//			function Start () {
			//				gameBoard = Instantiate(gameBoardPrefab, Vector3.zero, Quaternion.identity);
			//				gBcomponent = gameBoard.GetComponent(gameBoardScript);
			//			}
			//			
			//			function DoSomething () {
			//				gameBoard.gBcomponent.foo = "bar"; //Set foo : String in gameBoardScript to "bar"
			//				gameBoard.gBcomponent.foo(); //Run function foo() in gameBoardScript
			//			}
			
			//			var clone : prefabType ; //Transform, Rigidbody, whatever it is that you have for ur prefab slot  eg prefab : Rigidbody ;
			//			clone = Instantiate(prefab, yourposition, yourrotation) ;
			//			var cloneScript : NameOfScript ;
			//			cloneScript = clone.gameObject.GetComponent(NameOfScript) as NameOfScript ;
			//			cloneScript.FunctionNameInItImTryingToDo() ;
			//sphere.renderer.material.color = new Color(0.1, 0.1, 0.1, 1);
			
			//sphere.transform.localScale = new Vector3  (size, size, size);
			count++;
		}
		//system createdSystem = Instantiate(system, new Vector3 (Random.Range (0, 10), 0, Random.Range (0, 10)), Quaternion.identity) as system;
		//createdSystem.ChangeColour(new Color(1F, 0, 1F));
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
