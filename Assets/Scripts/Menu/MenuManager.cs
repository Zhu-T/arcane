using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    AudioSource click;
    private void Start()
    {
        click = GetComponent<AudioSource>();
        var check = PlayerPrefs.GetInt("FirstGame");
        if(check == 0)
        {
            PlayerPrefs.SetInt("SFX",5);
            PlayerPrefs.SetInt("BGM", 100);
            PlayerPrefs.SetInt("FirstGame", 1);
        }
        click.volume = (PlayerPrefs.GetInt("BGM") / 100);
    }
    public void ToGame()
    {
        click.Play();
        SceneManager.LoadScene("Game");
    }
    public void ToScores()
    {
        click.Play();
        SceneManager.LoadScene("Scores");
    }
    public void ToSettings()
    {
        click.Play();
        SceneManager.LoadScene("Settings");
    }
    public void ToMain()
    {
        click.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
