using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

	// Use this for initialization
	public void Init()
    {
        gameObject.SetActive(true);
    }
    public void Res()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
