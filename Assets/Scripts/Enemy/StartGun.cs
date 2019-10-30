using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGun : MonoBehaviour {

    // Use this for initialization
public void Init()
    {
        gameObject.SetActive(true);
    }
public void Stop()
    {
        gameObject.SetActive(false);
    }
}
