using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
	Bundeshaus = 0,
	Stadttheater = 1,
	Zytglogge = 2
}

public class spawnBlocks : MonoBehaviour
{
	public Level level = Level.Bundeshaus;
	public bool hookIsEmpty = true;

	private List<GameObject> startElements = new List<GameObject>();
	//private List<GameObject> undroppedElements = new List<GameObject>();
	private List<GameObject>.Enumerator blocksEnumerator;

	// Use this for initialization
	void Start ()
	{
		GameObject buildingpart = null;

		switch (level)
		{
			case Level.Bundeshaus:
				buildingpart = (GameObject)Instantiate(new GameObject("Bundeshaus_fragment_01"));
				buildingpart.SetActive(false);
				startElements.Add(buildingpart);
				buildingpart = (GameObject)Instantiate(new GameObject("Bundeshaus_fragment_01"));
				buildingpart.SetActive(false);
				startElements.Add(buildingpart);
				break;
			case Level.Stadttheater:
				break;
			case Level.Zytglogge:
				break;
			default:
				buildingpart = (GameObject)Instantiate(new GameObject("Bundeshaus_fragment_01"));
				buildingpart.SetActive(false);
				startElements.Add(buildingpart);
				break;
		}
		
		// todo
		//Shuffle(undroppedElements);
		
		blocksEnumerator = startElements.GetEnumerator();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButton("Fire1") && this.hookIsEmpty)
		{
			blocksEnumerator.MoveNext();
			GameObject buildingPart = blocksEnumerator.Current;
			Debug.Log(buildingPart);
			buildingPart.transform.position = transform.position;
			buildingPart.SetActive(true);
			Debug.Log(transform.position);
		}
	}
}
