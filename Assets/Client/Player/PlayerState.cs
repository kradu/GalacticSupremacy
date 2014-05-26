using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {
	

	public float incomeTime = 1f;
	public int id;
	public int income = 10;
	public int credits= 10;

	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {
		// this should happen serverside instead!
		InvokeRepeating("addIncome", incomeTime, incomeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void addIncome () {
		// should be serverside!
		credits += income;
	}

	public int getIncome () {
		return income;
	}

	public int getCredits () {
		return credits;
	}
}
