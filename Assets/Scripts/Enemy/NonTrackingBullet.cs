using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonTrackingBullet : MonoBehaviour
{

    public float speed = 8f;
    public float direction = 0f;

// Use this for initialization
void Start()
{
}

// Update is called once per frame
void Update()
{
    //Current Bullet Postion
    Vector2 postion = transform.position;
    
    //New Bullet Position
    if(direction == 1)
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
    if(direction == 2)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
    if(direction == -2)
        {
            transform.position += -transform.right * Time.deltaTime * speed;
        }
    if(direction == -1)
        {
            transform.position += -transform.up * Time.deltaTime * speed;
        }
    //Screen height
    Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//Bottom Left of Screen
    if ((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
    {
        Destroy(gameObject);
        }
    }
}
