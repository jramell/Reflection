using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishLevel : MonoBehaviour {

	int touching; //when it is 2, victory. 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTrigerStay(Collider col)
	{

	}

	 void VerifyVictory(bool touchingu)
	{
		if (touchingu) {
			touching++;
		} 
		else 
		{
			touching--;
		} 

		if (touching == 2) {
			Win ();
		}
	}

	void Win()
	{
		Text textoWin = GameObject.Find ("Text").GetComponent<Text>();
		textoWin.text = "¡HAS GANADO!";
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		for (int i = 0; i < players.Length; i++) 
		{
			Destroy(players[i]);
		}
	
	}
}
