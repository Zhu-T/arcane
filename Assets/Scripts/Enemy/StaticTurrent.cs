using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTurrent : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;
    public GameObject player;
    public float firerate = .2f;
    public float nextFire = 0f;
    private float time = 0f;
    // Use this for initialization
    void Start()
    {
    }
    private void Update()
    {
        time = Time.timeSinceLevelLoad;
        if (player != null)
        {
            if (time > nextFire)
            {
                nextFire = Time.timeSinceLevelLoad + firerate;
                Instantiate(bullet, gun.position, transform.rotation);
            }
        }
    }
}

