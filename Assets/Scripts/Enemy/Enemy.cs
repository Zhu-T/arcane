using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float speed;
    //private Vector3 startPos;
    public GameObject ExplosionAnim;
    public GameObject GameManager;
    public GameObject ScoreNumber;
    public GameObject player;
    public GameObject[] guns;
    public GameObject hitanim;
    private float maxX ;
    private float minX;
    private float maxY;
    private float Scale;
    private Vector2 position;
    private float tChange = 1f;
    private float randomX;
    private float randomY;
    private float RandomX;
    private float RandomY;
    private float RandomAnim;
    private bool movetoplayer = false;
    private bool change = true;
    private int hardmode;
    Animator anim;
    AudioSource[] hit;
    private bool laughplayed = false;
    void Start()
    {
        hardmode = PlayerPrefs.GetInt("Hardmode");
        int BGMSound = PlayerPrefs.GetInt("BGM");
        hit = GetComponents<AudioSource>();
        hit[0].volume = (BGMSound / 100);
        hit[1].volume = (BGMSound / 100);
        //startPos = transform.position;
        ScoreNumber = GameObject.FindGameObjectWithTag("Score");
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        //Determines Edges of Screen Based on main camera
        minX = bottomCorner.x;
        maxX = topCorner.x;
        maxY = topCorner.y;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // change to random direction at random intervals
        //Vector3.Distance(object player, object gameObject);
        if (Time.time >= tChange)
        {
            randomX = Random.Range(-5,5);
            randomY = Random.Range(-5,5);
            tChange = Time.time + Random.Range(3, 5);
            RandomAnim = Random.Range(0, 100);
            if (RandomAnim > 33.3 && RandomAnim <= 66.6)
            {
                StartCoroutine(Laugh());
            }
            if (RandomAnim > 66.6)
            {
                StartCoroutine(Attack());
            }
        }
        if (movetoplayer == true)
        {
            var playerpos = player.transform.position;
            randomX = playerpos.x;
            randomY = playerpos.y + 1;
            tChange = Time.time + 2;
            movetoplayer = false;
        }
        transform.Translate(new Vector2(randomX, randomY) * speed * Time.deltaTime);
        // if object reached any border, revert the appropriate direction
        if((transform.position.x < minX) || (transform.position.x > maxX)){
            randomX = -randomX;
        }
        if ((transform.position.y < 0) || (transform.position.y > maxY))
        {
            randomY = -randomY;
        }
        if ((ScoreNumber.GetComponent<ScoreUIText>().Score >= 10000) && (change == true)){
            if(hardmode == 1)
            {
                guns[0].GetComponent<StartGun>().Stop();
                guns[2].GetComponent<StartGun>().Init();
                change = false;
            }
            else
            {
                guns[0].GetComponent<StartGun>().Stop();
                guns[1].GetComponent<StartGun>().Init();
                change = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)//Collision Detection
    {
        if (col.tag == "PlayerBullet")
        {
            hit[0].Play();
            GameObject hitanimation = (GameObject)Instantiate(hitanim);
            hitanimation.transform.position = transform.position;
            if (hardmode == 1)
            {
                ScoreNumber.GetComponent<ScoreUIText>().Score += 400;
            }
            else
            {
                ScoreNumber.GetComponent<ScoreUIText>().Score += 200;
            }
        }
    }
    public void Init()
    {
        gameObject.SetActive(true);
    }
    public void Res()
    {
        gameObject.SetActive(false);
    }
    public void Toplayer()
    {
        movetoplayer = true;
    }
    public void laugh()
    {
        
        if (laughplayed == true)
        {
            laughplayed = false;
        }
        else
        {
            hit[1].Play();
            laughplayed = true;
        }
    }
    private IEnumerator Laugh()
    {
        anim.SetFloat("Laugh", 1);
        yield return new WaitForSeconds(5);
        anim.SetFloat("Laugh", -1);
    }
    private IEnumerator Attack()
    {
        anim.SetFloat("Attack", 1);
        yield return new WaitForSeconds(5);
        anim.SetFloat("Attack", -1);
    }
}