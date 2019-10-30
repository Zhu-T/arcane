using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {

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
