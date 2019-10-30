using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {
    public GameObject Boss;
    private float tchange = 0;
    private void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "PlayerShip" && Time.time > tchange)
        {
            Boss.GetComponent<Enemy>().Toplayer();
            tchange = Time.time + 5;
        } 
    }
}
