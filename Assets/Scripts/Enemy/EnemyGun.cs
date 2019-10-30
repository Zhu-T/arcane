using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet;
    public float fireRate = 0.0F;
    public float nextFire = 5F;
    private float time = 0f;
    // Use this for initialization
    void Start()
    {
    }
  
    // Update is called once per frame
    void Update()
    {
        GameObject ship = GameObject.Find("Player");//Finds Player
        time = Time.timeSinceLevelLoad;
        if (ship != null)//If player alive shoot at it
        {
            if (time > nextFire)
            {
                nextFire = Time.timeSinceLevelLoad + fireRate;
                GameObject bullet = (GameObject)Instantiate(EnemyBullet);//Create bullet
                bullet.transform.position = transform.position;//Get bullet position
            }
        }
    }
}
