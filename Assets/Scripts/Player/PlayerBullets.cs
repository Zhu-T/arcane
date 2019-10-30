using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour {
    public float speed = 8f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //Current Bullet Position
        Vector2 postion = transform.position;

        //New Bullet Postion
        postion = new Vector2(postion.x, postion.y + speed * Time.deltaTime);
        transform.position = postion;

        //Screen height
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D col)//Collision Detection
    {
        if (col.tag == "BossShip")
        {
            Destroy(gameObject);
        }
    }
}
