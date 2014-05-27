using UnityEngine;
using System.Collections;
using gsFramework;

// server side class, needs 1 instance per player
public class PlayerState : MonoBehaviour {
	
	public int id;
	public float incomeTime = 1f;
	public int income = 10;
	public int credits = 10;
	//public SolReg[] regions;

	void Awake () {
		// keep this object instance when transitioning between scenes.
		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {
		// in incomeTime intervals, run "addIncome"
		InvokeRepeating("computeIncome", incomeTime, incomeTime);
		InvokeRepeating("addIncome", incomeTime, incomeTime);
	}
	
	void Update () {
	}

	/* computeIncome can get called by the client to request a recomputation
	 * of the income stat. 
	 *
	 */
	public void computeIncome () {
		// find all regions where SolReg.owner == player.id
		income = 0;
		for (int i = 0; i < generatePlanets.numRegions; ++i) {
			if (generatePlanets.regions[i].owner == id) {
				income += generatePlanets.regions[i].income;
				for (int j = 0; j < generatePlanets.regions[i].slots; ++j) {
					income += generatePlanets.regions[i].buildings[j].income;	
				}
			}
		}
	}

	/* Increments the players credits by his current income.
	 */
	void addIncome () {
		credits += income;
	}

	public int getIncome () {
		return income;
	}

	public int getCredits () {
		return credits;
	}
}
