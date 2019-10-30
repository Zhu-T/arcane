using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour {
    public Slider Slider1;
    public Slider Slider2;
    public Text Text1;
    public Text Text2;
    public Toggle Hardmode;
	// Use this for initialization
	void Start () {
        Slider1.value = PlayerPrefs.GetInt("BGM");
        Slider2.value = PlayerPrefs.GetInt("SFX");
        Text1.text = Slider1.value.ToString() + "%";
        Text2.text = Slider2.value.ToString() + "%";
        if(PlayerPrefs.GetInt("Hardmode") == 1)
        {
            Hardmode.isOn = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(Hardmode.isOn == true)
        {
            PlayerPrefs.SetInt("Hardmode", 1);
        }
        PlayerPrefs.SetInt("BGM", (int)Slider1.value);
        PlayerPrefs.SetInt("SFX", (int)Slider2.value);
        Text1.text = Slider1.value.ToString() + "%";
        Text2.text = Slider2.value.ToString() + "%";
    }
}
