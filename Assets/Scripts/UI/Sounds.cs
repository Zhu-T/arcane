using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sounds : MonoBehaviour {
    private float SFXSound;
    private float BGMSound;
    public int BGM_SFX;
    public int Donotdestroy;
    public int Scene;
    // Use this for initialization
    void Start () {
        if (FindObjectsOfType(GetType()).Length == 2)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        var sound = gameObject.GetComponent<AudioSource>();
        SFXSound = PlayerPrefs.GetInt("SFX");
        BGMSound = PlayerPrefs.GetInt("BGM");
        if(BGM_SFX == 0)
        {
            sound.volume = BGMSound/100;
        }
        else
        {
            sound.volume = SFXSound/100;
        }
        if (Donotdestroy == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (Scene == 1)
        {
            if (sceneName == "Game")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
        if (Scene == 2)
        {
            if (sceneName == "MainMenu")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}
