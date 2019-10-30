using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    public float speed = 10f;
    private float minX, maxX, minY, maxY;
    public GameObject ExplosionAnim;
    public GameObject GameManagerGO;
    public GameObject[] guns;
    public GameObject joystickimg;
    public float lastfired;
    public float fireRate = 0.2f;
    public float invincibletime = 3f;
    public GameObject ScoreNumber;
    //private float shottime = 20f;
    private Animator anim;
    private int startHP;
    private int curHP = 3;
    public Image[] Health;
    public Sprite empty;
    public Sprite full;
    private Renderer rend;
    private Color C;
    private bool invunerable = false;
    private float count = 0;
    private bool buff = false;
    private int choose = 0;
    private float axisx;
    private float axisy;
    AudioSource[] hit;
    public JoyStick joystick;

    // Use this for initialization
    void Start () {
        int BGMSound = PlayerPrefs.GetInt("BGM");
        anim = GetComponent<Animator>();
        ScoreNumber = GameObject.FindGameObjectWithTag("Score");
        //For Invincible Animation
        rend = GetComponent<Renderer>();
        C = rend.material.color;
        //Finds main camera edges
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        //Determines Edges of Screen Based on main camera
        minX = bottomCorner.x;
        maxX = topCorner.x;
        minY = bottomCorner.y;
        hit = GetComponents<AudioSource>();
        hit[0].volume = BGMSound / 100;
        hit[1].volume = BGMSound / 100;
        guns[0].GetComponent<StartGun>().Init();
	}

    // Update is called once per frame
    void Update()
    {
        if (Time.time > count && buff == true)
        {
            guns[2].GetComponent<StartGun>().Stop();
            guns[1].GetComponent<StartGun>().Stop();
            guns[0].GetComponent<StartGun>().Init();
            buff = false;
        }
        ScoreNumber.GetComponent<ScoreUIText>().Score += 1;
        //Get Input

#if UNITY_ANDROID
         Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y));

        transform.position = new Vector3(pos.x, pos.y);
#else
        axisx = Input.GetAxis("Horizontal");
        axisy = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;
#endif
        if (axisx != 0 || axisy != 0)
        {
            // Get current position

            // Horizontal contraint 
            if (pos.x < minX) pos.x = minX;
            if (pos.x > maxX) pos.x = maxX;

            // vertical contraint
            if (pos.y < minY) pos.y = minY;
            if (pos.y > 2) pos.y = 2;

            // Update position
            transform.position = pos;
            transform.Translate(new Vector3(axisx, axisy) * Time.deltaTime * speed);

            anim.SetFloat("MoveX", Input.GetAxis("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxis("Vertical"));
        }
    }
    private void OnTriggerEnter2D(Collider2D col)//Collision Detection
    {
     if(((col.tag == "BossShip") || (col.tag == "EnemyBullet")) && invunerable == false)
        {
            hit[0].Play();
            curHP = curHP - 1;
            if (curHP == 2)
            {       
                Health[2].sprite = empty;
            }
            else if (curHP == 1)
            {
                Health[1].sprite = empty;
            }
            else if(curHP <= 0)
            {
                Health[0].sprite = empty;
                hit[1].Play();
                gameObject.SetActive(false);
                Death();
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
            }
            invunerable = true;
            StartCoroutine(Invincible());
        }
     if(col.tag == "HPPotion")
        {
            if(curHP == 3)
            {
                ScoreNumber.GetComponent<ScoreUIText>().Score += 1000;
            }
            else if (curHP == 2)
            {
                Health[2].sprite = full;
                curHP = curHP + 1;
            }
            else if (curHP == 1)
            {
                Health[1].sprite = full;
                curHP += 1;
            }
        }
     if(col.tag == "TripleShot")
        {
            choose = Random.Range(0, 100);
            if(buff == true)
            {
                count = Time.time + 15;
            }
            else
            {
                if (choose <= 25)
                {
                    invunerable = true;
                    StartCoroutine(Invincible());
                }
                if ((choose > 25) || (choose <= 67))
                {
                    guns[0].GetComponent<StartGun>().Stop();
                    guns[2].GetComponent<StartGun>().Stop();
                    guns[1].GetComponent<StartGun>().Init();
                    count = Time.time + 15;
                    buff = true;
                }
                if (choose >= 68)
                {
                    guns[0].GetComponent<StartGun>().Stop();
                    guns[1].GetComponent<StartGun>().Stop();
                    guns[2].GetComponent<StartGun>().Init();
                    count = Time.time + 15;
                    buff = true;
                }
            }
        }
    }
    
    void Death()
    {
        GameObject explosion = (GameObject)Instantiate (ExplosionAnim);
        explosion.transform.position = transform.position;
    }
    IEnumerator Invincible()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        C.a = 0.5f;
        rend.material.color = C;
        yield return new WaitForSeconds(invincibletime);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        C.a = 1f;
        rend.material.color = C;
        invunerable = false;
    }
    public void Init()
    {
        gameObject.SetActive(true);
    }
    public void Res()
    {
        gameObject.SetActive(false);
    }
}