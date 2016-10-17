using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	GameObject player;
	Ray ray;
	RaycastHit rayCastHit;
	bool firstTime;


	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		ray = new Ray (transform.position, transform.forward);
		firstTime = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (firstTime) 
		{
			if (Physics.Raycast (ray, out rayCastHit, 1000))
			{
				if (rayCastHit.collider.tag == "Player")
				{
					transform.parent = player.transform;
				}
			}
		}


	}
}
