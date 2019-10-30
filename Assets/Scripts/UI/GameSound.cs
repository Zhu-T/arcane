using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float SFXSound = PlayerPrefs.GetInt("SFX");
        var sound = gameObject.GetComponent<AudioSource>();
        sound.volume = SFXSound / 100;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
