using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SmokeOnCollision : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		ContactPoint2D[] contacts = new ContactPoint2D[collision.contactCount];
		collision.GetContacts(contacts);
		Debug.Log(collision.contactCount);

		for (int i = 0; i < collision.contactCount; i++)
		{
			GameObject collisionSmoke;
			collisionSmoke = (GameObject)Instantiate(
				   Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "smokeParticles")
			   );
			collisionSmoke.transform.position = contacts[i].point;
		}
	}
}
