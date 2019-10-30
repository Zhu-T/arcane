﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIText : MonoBehaviour {
    Text ScoreUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScore();
        }
    }

	// Use this for initialization
	void Start () {
        ScoreUI = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void UpdateScore () {
        string scoreStr = string.Format("{0:0000000}", score);
        ScoreUI.text = scoreStr;
	}
}
