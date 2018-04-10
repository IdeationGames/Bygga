using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class playsoundkeyinput : MonoBehaviour {

	public AudioSource keya;
	public AudioSource keyd;
	public AudioSource arrowleft;
	public AudioSource arrowright;
	public AudioSource mouse1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {
            if (keya != null)
            {
                keya.Play();
            }
        }
		if (Input.GetKeyDown (KeyCode.D)) {
            if (keyd != null)
            {
                keyd.Play();
            }
        }
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
            if (arrowleft != null)
            {
                arrowleft.Play();
            }
        }
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
            if (arrowright != null)
            {
                arrowright.Play();
            }
        }
		if (Input.GetKeyDown (KeyCode.Mouse0)){
            if (mouse1 != null)
            {
                mouse1.Play();
            }
        }

	}
}
