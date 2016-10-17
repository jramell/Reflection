using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float minX;
	public float maxX;
	public float minZ;
	public float maxZ;
	bool touchedReflection;
	GameObject emitting;
	bool thereIsReflection;

	//La implementacion del siguiente bool es una mierda, porque solo funciona en el nivel actual.
	bool touchedObjective;

	// Use this for initialization
	void Start () 
	{
		touchedReflection = false;
		thereIsReflection = false;
		touchedObjective = false;
	}
	// Update is called once per frame
	void Update()
	{
		transform.position = new Vector3( 
		                                 Mathf.Clamp(transform.position.x, minX, maxX ),
		                                 0f,
		                                 Mathf.Clamp(transform.position.z, minZ, maxZ) );
	}

	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody>().velocity = ( new Vector3(horizontal * speed, 0f, vertical * speed) );
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Reflection_plate") {
			GameObject reflection_plate = col.gameObject;
			if (!touchedReflection && !thereIsReflection) {
				reflection_plate.SendMessage ("Touched", touchedReflection);
				touchedReflection = true;
			} else if (!thereIsReflection) {
				reflection_plate.SendMessage ("Reflect", emitting);
				thereIsReflection = true;
			}
		} 

		else if (col.tag == "Portal_plate") 
		{
			if(!touchedObjective)
			{
				GameObject Portal_plate = col.gameObject;
				Portal_plate.SendMessage("VerifyVictory", true);
				touchedObjective = true;
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Portal_plate") {
			GameObject Portal_plate = col.gameObject;
			Portal_plate.SendMessage("VerifyVictory", false);
			touchedObjective = false;
		}
	}

	void GetWhoIsEmitting(GameObject emitting2)
	{
		emitting = emitting2;	
	}
}
