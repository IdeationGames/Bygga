using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class comparePlacement : MonoBehaviour
{
    public bool runComparison = true;

    private GameObject currentFragment;
    private bool isResting
    {
        get; set;
    }

	// Use this for initialization
	void Start ()
    {
        currentFragment = this.gameObject;
        isResting = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (runComparison && isResting)
        {
            SpriteRenderer[] allSpriteObjs = FindObjectsOfType<SpriteRenderer>();
            SpriteRenderer currentSpriteRenderer = currentFragment.GetComponent<SpriteRenderer>();
            for (int i = 0; i < allSpriteObjs.Length; i++)
            {
                if (currentSpriteRenderer.sprite == allSpriteObjs[i].sprite
                    && !allSpriteObjs[i].Equals(currentSpriteRenderer))
                {
                    float distance = Vector2.Distance(allSpriteObjs[i].transform.position, currentSpriteRenderer.transform.position);
                    globalInfo.gameScoreFromDistance(distance);
                    runComparison = false;

                    GameObject explosion1 = (GameObject)Instantiate(
                        Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Effects" + Path.DirectorySeparatorChar + "explosionAnim")
                    );
                    GameObject explosion2 = (GameObject)Instantiate(
                        Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Effects" + Path.DirectorySeparatorChar + "explosionAnim")
                    );
                    GameObject explosion3 = (GameObject)Instantiate(
                        Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Effects" + Path.DirectorySeparatorChar + "explosionAnim")
                    );

                    Vector3 positionBottomLeft = currentSpriteRenderer.bounds.center - currentSpriteRenderer.bounds.extents;
                    Vector3 positionBottomMiddle = currentSpriteRenderer.bounds.center - currentSpriteRenderer.bounds.extents;
                    Vector3 positionBottomRight = currentSpriteRenderer.bounds.center - currentSpriteRenderer.bounds.extents;
                    positionBottomMiddle.x += currentSpriteRenderer.bounds.extents.x;
                    positionBottomRight.x += currentSpriteRenderer.bounds.extents.x * 2;

                    explosion1.transform.position = positionBottomLeft;
                    explosion2.transform.position = positionBottomMiddle;
                    explosion3.transform.position = positionBottomRight;
                }
            }
        }
        
        if (currentFragment.GetComponent<Rigidbody2D>().IsSleeping())
        {
            isResting = true;
        }
	}
}
