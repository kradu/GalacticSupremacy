using UnityEngine;
using System.Collections;


// server side class, needs 1 instance per player
public class PlayerState : MonoBehaviour {
	

	public float incomeTime = 1f;
	public int id;
	public int income = 10;
	public int credits= 10;

	void Awake () {
		// keep this object instance when transitioning between scenes.
		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {
		// every incomeTime seconds, increment the income
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
		// add up their income values
		// set this.income = sum of income values
	}

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
