using UnityEngine;
using System.Collections;

public class ReflectScript : MonoBehaviour {

	bool touched;

	// Use this for initialization
	void Start () 
	{
		touched = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter(Collider col)
	{

	}

	void Touched(bool touchedAnother)
	{
		touched = touchedAnother; //touched = true
			GetComponent<ParticleSystem>().Play();
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.SendMessage("GetWhoIsEmitting", gameObject);

	}

	void Reflect(GameObject emitting)
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		bool isNotTheSame = gameObject.name != emitting.name;
		if (isNotTheSame) 
		{
			if ( emitting.GetComponent<ParticleSystem>().isPlaying )
			{
				emitting.GetComponent<ParticleSystem>().enableEmission = false;
				emitting.GetComponent<ParticleSystem>().Clear();
			}

			Instantiate (player, emitting.transform.position, Quaternion.identity);
		}
	}
}
