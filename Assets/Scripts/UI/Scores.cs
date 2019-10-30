using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
    public static Scores Instance;
    public Text RecentscoreText;
    public Text HighscoreText;
	// Use this for initialization
	void Start () {
        Instance = this;
        RecentscoreText.text = PlayerPrefs.GetInt("RecentScore").ToString();
        HighscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
        if (PlayerPrefs.GetInt("Highscore") <= PlayerPrefs.GetInt("RecentScore"))
        {
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("RecentScore"));
            HighscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetScore()
    {
        if(PlayerPrefs.GetInt("Highscore") <= PlayerPrefs.GetInt("RecentScore")){
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("RecentScore"));
            HighscoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
    }
}
