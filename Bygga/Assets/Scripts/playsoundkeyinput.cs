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
			keya.Play();
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			keyd.Play();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			arrowleft.Play();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			arrowright.Play();
		}
		if (Input.GetKeyDown (KeyCode.Mouse0)){
			mouse1.Play();
		}

	}
}
