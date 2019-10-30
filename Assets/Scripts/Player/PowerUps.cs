using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public float speed;
    AudioSource sound;
    private float BGMSound;
    private SpriteRenderer Rend;
    private bool trig = true;
    private BoxCollider2D collider; 
    // Use this for initialization
    void Start() {
        BGMSound = PlayerPrefs.GetInt("BGM");
        sound = GetComponent<AudioSource>();
        sound.volume = BGMSound / 100;
        Rend = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {
            Vector2 position = transform.position;
            position = new Vector2(position.x, position.y - speed * Time.deltaTime);
            transform.position = position;
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            if (transform.position.y < min.y)
            {
                Destroy(gameObject);
            }
        }
    void OnTriggerEnter2D(Collider2D col)//Collision Detection
    {
        if (col.tag == "PlayerShip")
        {
            if(trig == true)
            {
                collider.isTrigger = false;
                sound.Play();
                Rend.enabled = false;
                Destroy(gameObject, 3f);
                trig = false;
            }
        }
        }
    }