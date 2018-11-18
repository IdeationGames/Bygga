using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum Level
{
	Bundeshaus = 0,
	Stadttheater = 1,
	Zytglogge = 2,
	Chindlifresser = 3,
	Kornhausbruecke = 4
}

public class spawnBlocks : MonoBehaviour
{
	public Level level = Level.Bundeshaus;
	private bool hookIsEmpty = true;

	private List<GameObject> startElements = new List<GameObject>();
	//private List<GameObject> undroppedElements = new List<GameObject>();
	private List<GameObject>.Enumerator blocksEnumerator;

    private GameObject activeBuildingPart;

    // input handling
    private bool spawnBtnClicked = false;
    private bool spawnBtnDown = false;
    private float timeSinceLastClick = 0.0f;
    private float minimumSecondsBeteenClicks = 0.1f;

    // Use this for initialization
    void Start ()
	{
		GameObject buildingpart = null;
        timeSinceLastClick = Time.timeSinceLevelLoad;

        switch (level)
		{
			case Level.Bundeshaus:
                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Bundeshaus" + Path.DirectorySeparatorChar + "fragment_01")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Bundeshaus" + Path.DirectorySeparatorChar + "fragment_02")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Bundeshaus" + Path.DirectorySeparatorChar + "fragment_03")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

				buildingpart = (GameObject)Instantiate(
					Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Bundeshaus" + Path.DirectorySeparatorChar + "fragment_04")
				);
				buildingpart.transform.parent = this.transform;
				buildingpart.GetComponent<Rigidbody2D>().simulated = false;
				buildingpart.SetActive(false);
				startElements.Add(buildingpart);

				buildingpart = (GameObject)Instantiate(
					Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Bundeshaus" + Path.DirectorySeparatorChar + "fragment_05")
				);
				buildingpart.transform.parent = this.transform;
				buildingpart.GetComponent<Rigidbody2D>().simulated = false;
				buildingpart.SetActive(false);
				startElements.Add(buildingpart);

				buildingpart = (GameObject)Instantiate(
					Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Bundeshaus" + Path.DirectorySeparatorChar + "fragment_06")
				);
				buildingpart.transform.parent = this.transform;
				buildingpart.GetComponent<Rigidbody2D>().simulated = false;
				buildingpart.SetActive(false);
				startElements.Add(buildingpart);

                break;
			case Level.Stadttheater:
				break;
			case Level.Zytglogge:
				break;
			case Level.Chindlifresser:
                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Chindlifraesser" + Path.DirectorySeparatorChar + "fragment_01")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Chindlifraesser" + Path.DirectorySeparatorChar + "fragment_02")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Chindlifraesser" + Path.DirectorySeparatorChar + "fragment_03")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);



				break;
			case Level.Kornhausbruecke:
                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Kornhausbruecke" + Path.DirectorySeparatorChar + "fragment_01")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Kornhausbruecke" + Path.DirectorySeparatorChar + "fragment_02")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Kornhausbruecke" + Path.DirectorySeparatorChar + "fragment_03")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                   Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Kornhausbruecke" + Path.DirectorySeparatorChar + "fragment_04")
               );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);


				break;
			default:
				break;
		}
        		
		// todo
		//Shuffle(undroppedElements);
		
		blocksEnumerator = startElements.GetEnumerator();
	}
	
	// Update is called once per frame
	void Update ()
	{
        // handle clickevent
        if (Input.GetButtonDown("Fire1") && (Time.timeSinceLevelLoad - timeSinceLastClick > minimumSecondsBeteenClicks))
        {
            spawnBtnDown = true;
            timeSinceLastClick = Time.timeSinceLevelLoad;
        }
        else if (Input.GetButtonUp("Fire1") && spawnBtnDown)
        {
            spawnBtnDown = false;
            this.spawnBtnClicked = true;
        }

        // spawn or drop when clicked
        if (this.spawnBtnClicked && this.hookIsEmpty)
		{
            this.spawnBtnClicked = false;
            this.hookIsEmpty = false;

            if (blocksEnumerator.MoveNext())
            {
                activeBuildingPart = blocksEnumerator.Current;
                activeBuildingPart.transform.position = transform.position;
                activeBuildingPart.SetActive(true);
            }
            else
            {
                activeBuildingPart = null;
            }
		}
        else if (this.spawnBtnClicked && !this.hookIsEmpty)
        {
            this.spawnBtnClicked = false;
            this.hookIsEmpty = true;

            if (activeBuildingPart != null)
            {
                activeBuildingPart.GetComponent<Rigidbody2D>().simulated = true;
                activeBuildingPart.transform.parent = null;
                activeBuildingPart.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity;
            }
        }
    }
}
