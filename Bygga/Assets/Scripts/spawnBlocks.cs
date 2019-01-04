using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

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
	public GameObject levelChangeCanvas;
	public Button nextLevelButton;
	public Text timerText;
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
	private bool fireButtonDown = false;

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
                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Stadttheater" + Path.DirectorySeparatorChar + "fragment_01")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Stadttheater" + Path.DirectorySeparatorChar + "fragment_02")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Stadttheater" + Path.DirectorySeparatorChar + "fragment_03")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Stadttheater" + Path.DirectorySeparatorChar + "fragment_04")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Stadttheater" + Path.DirectorySeparatorChar + "fragment_05")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);


				break;
			case Level.Zytglogge:
                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Zytglocke" + Path.DirectorySeparatorChar + "fragment_01")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Zytglocke" + Path.DirectorySeparatorChar + "fragment_02")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Zytglocke" + Path.DirectorySeparatorChar + "fragment_03")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);

                buildingpart = (GameObject)Instantiate(
                    Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Zytglocke" + Path.DirectorySeparatorChar + "fragment_04")
                );
                buildingpart.transform.parent = this.transform;
                buildingpart.GetComponent<Rigidbody2D>().simulated = false;
                buildingpart.SetActive(false);
                startElements.Add(buildingpart);


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
		if(Input.GetButtonDown("Fire1"))
		{
			this.fireButtonDown = true;
		}
		else if (Input.GetButtonUp("Fire1"))
		{
			this.fireButtonDown = false;
		}
		//Debug.Log(this.fireButtonDown);
		Debug.Log(Input.GetButtonDown("Fire1"));

		// handle clickevent
		if (this.fireButtonDown && (Time.timeSinceLevelLoad - timeSinceLastClick > minimumSecondsBeteenClicks))
        {
            spawnBtnDown = true;
            timeSinceLastClick = Time.timeSinceLevelLoad;
        }
        else if (this.fireButtonDown && spawnBtnDown)
        {
			this.fireButtonDown = false;
			spawnBtnDown = false;
            this.spawnBtnClicked = true;
        }

		updateTimer();

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

		displayLevelChangeCanvasAfterFinish();
		displayMenuOnEsc();
	}

	private void updateTimer()
	{
		if (!this.hookIsEmpty)
		{
			float timeLeft = (10.0f) - (Time.timeSinceLevelLoad - timeSinceLastClick);
			int beforeDecimal = int.Parse(timeLeft.ToString().Split('.')[0]);
			int firstTwoDecimalPlaces = (int)(((decimal)timeLeft % 1) * 100);
			timerText.text = beforeDecimal.ToString() + ":" + firstTwoDecimalPlaces.ToString();

			if (timeLeft < 0.0f)
			{
				this.fireButtonDown = true;
			}
		}
		else
		{
			timerText.text = "10:00";
		}
	}

	private void displayLevelChangeCanvasAfterFinish()
	{
		if (levelChangeCanvas != null)
		{
			List<GameObject>.Enumerator tempEnumerator = startElements.GetEnumerator();
			bool allPlaced = true;

			while(tempEnumerator.MoveNext())
			{
				GameObject currentObj = tempEnumerator.Current;
				if (!currentObj.GetComponent<Rigidbody2D>().IsSleeping())
				{
					allPlaced = false;
				}
			}

			// player must have 100 points for the level to complete
			if (globalInfo.getGameScore() > 100)
			{
				if (nextLevelButton != null)
				{
					nextLevelButton.interactable = true;
				}
				else
				{
					Debug.LogWarning("next level button not referenced");
				}
			}

			if (allPlaced)
			{
				levelChangeCanvas.SetActive(true);
			}
		}
		else
		{
			Debug.LogWarning("no Canvas to display referenced");
		}
	}

	private void displayMenuOnEsc()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			if (levelChangeCanvas != null)
			{
				levelChangeCanvas.SetActive(!levelChangeCanvas.activeSelf);
			}
		}
	}
}
