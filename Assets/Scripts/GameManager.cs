using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject Boss;
    public GameObject GameOverScreen;
    public GameObject Score;
    public GameObject HP;
    public GameObject ScoreUI;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

	// Use this for initialization
	void Start () {
        Invoke("StartGame", 2f);
    }
	
	// Update is called once per frame
	void UpdateGameManagerState () {
		switch(GMState)
        {
            case GameManagerState.Gameplay:
                //Show Sprites
                player.GetComponent<Movement>().Init();
                Boss.GetComponent<Enemy>().Init();
                HP.GetComponent<HP>().Init();
                ScoreUI.GetComponent<ScoreUI>().Init();
                Score.GetComponent<ScoreUIText>().Score = 0;
                break;
            case GameManagerState.GameOver:
                Invoke("Gameover", 3f);
                PlayerPrefs.SetInt("RecentScore", Score.GetComponent<ScoreUIText>().Score);
                GameOverScreen.SetActive(true);
                player.SetActive(false);
                Boss.SetActive(false);
                break;
        }
	}
    public void SetGameManagerState(GameManagerState State)
    {
        GMState = State;
        UpdateGameManagerState();
    }
    public void StartGame()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }
    public void Gameover()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
