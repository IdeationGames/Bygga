using UnityEngine;
using System.Collections;

public class destroyObject : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D col)
	{
		//Check collision name
		Debug.Log ("collision name = " + col.gameObject.name);
		if (col.gameObject.name == "fragment_01 (1)") {
			Destroy (col.gameObject);
		}
	}
}