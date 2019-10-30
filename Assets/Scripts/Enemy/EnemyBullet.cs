using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5f;
    private float minX;
    private float minY;
    private float maxY;
    private float maxX;

    // Use this for initialization
    private void Awake()
    {
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //Current Bullet Position
        Vector2 postion = transform.position;

        //New Bullet Postion
        postion = new Vector2(postion.x, postion.y + speed * Time.deltaTime);
        transform.position = postion;

        //Screen height
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //X axis      
        if (transform.position.x <= min.x)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x >= max.x)
        {
            Destroy(gameObject);
        }

        // Y axis
        if (transform.position.y <= min.y)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y >= max.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)//Collision Detection
    {
        if (col.tag == "PlayerShip")
        {
            Destroy(gameObject);
        }
    }
}
