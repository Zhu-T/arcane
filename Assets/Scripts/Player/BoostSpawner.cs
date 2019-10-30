using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostSpawner : MonoBehaviour {
    public GameObject Triple;
    public GameObject HP;
    private int Rand;
    private float SpawnRate = 5f;
    private bool spawn = true;
    // Use this for initialization
    void Start () {
        Invoke("SpawnPowerUp", SpawnRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnPowerUp()
    {
        if(spawn == true)
        {
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Rand = Random.Range(0, 100);
            if (Rand >= 50)
            {
                GameObject buff = (GameObject)Instantiate(HP);
                buff.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                NextSpawn();
            }
            if (Rand < 49)
            {
                GameObject buff = (GameObject)Instantiate(Triple);
                buff.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
                NextSpawn();
            }
        }

    }
    void NextSpawn()
    {
        SpawnRate = Random.Range(5f, 15f);
        Invoke("SpawnPowerUp", SpawnRate);
    }
    public void stop()
    {
        spawn = false;
    }
}
