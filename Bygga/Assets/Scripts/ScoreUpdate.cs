﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    private Text textComponent;

    // Use this for initialization
    void Start ()
    {
        textComponent = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        textComponent.text = "" + globalInfo.getGameScore();
	}
}
