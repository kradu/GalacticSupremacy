using UnityEngine;
using System.Collections;
using gsFramework;


/* startup is the main class for the client. It holds information
 * about the player(ID) and queries the server for map data. It also
 * holds information about the players GUI interaction (selection).
 */ 
public class startup : MonoBehaviour {

	public generatePlanets regionServ;
	//public SolReg[] regions;
	private int numRegions;
	public SolReg selectedSR;
	GameObject selector;
	GameObject selected;
	GameObject guiController;

	/* Initialization. Queries the server for the data needed to build and
	 * render the map. This includes the number regions, and data
	 */
	void Start () {
		// This would be a server request:
		numRegions = generatePlanets.numRegions;
		//regions = new SolReg[numRegions];

		for (int i = 0; i < numRegions; ++i) {
			// This would be a server request:
			//regions[i] = generatePlanets.get_sol_reg(i);
			DrawRegion(generatePlanets.regions[i]);
		}
	}

	public void SelectSR(SolReg srSelection) {
		// If a previous selection exists, deselect. 
		if (selectedSR.id != 0) {
			print(selectedSR.id);
			selected.GetComponent<planetScript>().Deselect();
		}

		print("STARTUP: Selected Region "+srSelection.id);

		// Update current selection in this script.
		selectedSR = srSelection;
		selected = GameObject.Find("Region "+selectedSR.id);

		// Tell GUI which region is selected.
		guiController = GameObject.Find("MainGUI");
		guiController.GetComponent<MainGUI>().selectedSR = selectedSR;
	}

	GameObject CreateSelector() {
		GameObject selector = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		
		// selector is invisible until a selection is made
		selector.renderer.enabled = false;
		
		return selector;
	}

	void UpdateSelector(SolReg SR) {
		selector.renderer.enabled = true;
		selector.transform.localPosition = new Vector3(SR.x, 0.1f, SR.z);
		selector.transform.localScale = new Vector3(1.8f, 0, 1.8f);
		selector.renderer.material.color = Color.white;
	}

	void DrawRegion (SolReg region) {
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.localPosition = new Vector3(region.x, 0, region.z);
		sphere.transform.localRotation = Quaternion.Euler (90, 0, 0);

		Material mat = Resources.Load (region.texture, typeof(Material)) as Material;
		sphere.renderer.material = mat;
		Texture2D tex = Resources.Load (region.texture, typeof(Texture2D)) as Texture2D;
		sphere.renderer.material.mainTexture = tex;


		// attach script to the new sphere
		sphere.AddComponent("planetScript");
		
		// pass reference to region to the script
		sphere.GetComponent<planetScript>().SetSR(region);

		// give the GO a meaningful name
		sphere.name = "Region "+ region.id;
	}
}
