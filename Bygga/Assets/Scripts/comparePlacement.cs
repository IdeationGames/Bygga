using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class comparePlacement : MonoBehaviour
{
    public bool runComparison = true;

	private Vector3 previousPos = new Vector3(0, 0, 0);
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
                    // calculate score and update global score
                    float distance = Vector2.Distance(allSpriteObjs[i].transform.position, currentSpriteRenderer.transform.position);
                    globalInfo.gameScoreFromDistance(distance);
                    runComparison = false;
                    
                    // create explosions as visual feedback
                    GameObject explosion1 = (GameObject)Instantiate(
						Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Effects" + Path.DirectorySeparatorChar + "explosionAnimBW")
                    );
                    GameObject explosion2 = (GameObject)Instantiate(
						Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Effects" + Path.DirectorySeparatorChar + "explosionAnimBW")
                    );
                    GameObject explosion3 = (GameObject)Instantiate(
						Resources.Load("Prefabs" + Path.DirectorySeparatorChar + "Effects" + Path.DirectorySeparatorChar + "explosionAnimBW")
                    );

                    // set explosion position
                    Vector3 positionBottomLeft = currentSpriteRenderer.bounds.center - currentSpriteRenderer.bounds.extents;
                    Vector3 positionBottomMiddle = currentSpriteRenderer.bounds.center - currentSpriteRenderer.bounds.extents;
                    Vector3 positionBottomRight = currentSpriteRenderer.bounds.center - currentSpriteRenderer.bounds.extents;
                    positionBottomMiddle.x += currentSpriteRenderer.bounds.extents.x;
                    positionBottomRight.x += currentSpriteRenderer.bounds.extents.x * 2;

                    explosion1.transform.position = positionBottomLeft;
                    explosion2.transform.position = positionBottomMiddle;
                    explosion3.transform.position = positionBottomRight;

                    //  add destroy script
                    explosion1.AddComponent<AnimationAutoDestroy>();
                    explosion2.AddComponent<AnimationAutoDestroy>();
                    explosion3.AddComponent<AnimationAutoDestroy>();

                    // destroy blueprint
                    Destroy(allSpriteObjs[i]);
                }
            }
        }

		Rigidbody2D rb = currentFragment.GetComponent<Rigidbody2D>();
		float deltaX = this.previousPos.x - this.transform.position.x;
		float deltaY = this.previousPos.y - this.transform.position.y;
		//Debug.Log(deltaX + " " + deltaY + " " + rb.simulated + " " + rb.velocity.x + " " + rb.velocity.y);
		this.previousPos = this.transform.position;

		if (rb.simulated && deltaX == 0 && deltaY == 0 && Mathf.Abs(rb.velocity.x) < 0.001f && Mathf.Abs(rb.velocity.y) < 0.001f)
		{
			rb.Sleep();
		}

		if (rb.IsSleeping())
        {
            isResting = true;
        }
	}
}
