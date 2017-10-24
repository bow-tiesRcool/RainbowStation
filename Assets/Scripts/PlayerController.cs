using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController player;
    public GameObject playerPre;
    Vector3 pos;
    Vector3 dir;
    float angle;
    public string[] bulletColor;
    public int bulletNum;
    public Sprite[] GunName;
    public SpriteRenderer shield;
    public SpriteRenderer gun;
    public int rainbowChip = 0;
    public GameObject rainbow;
    public bool RainActive = false;

    private void Awake()
    {
        if (player == null)
        {
            player = this;
        }
    }

    void Start ()
    {
        //player.shield = GetComponentInChildren<SpriteRenderer>();
        player.shield.color = Color.green;
        gun = GetComponent<SpriteRenderer>();
    }
	
	void Update ()
    {

        pos = Camera.main.WorldToScreenPoint(transform.position);
        dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            bulletNum = 0;
            gun.sprite = GunName[0];
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            bulletNum = 1;
            gun.sprite = GunName[1];
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            bulletNum = 2;
            gun.sprite = GunName[2];
        }
         if (Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Alpha2))
        {
            bulletNum = 3;
            gun.sprite = GunName[3];
        }
        if (Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.Alpha3))
        {
            bulletNum = 4;
            gun.sprite = GunName[4];
        }
        if (Input.GetKey(KeyCode.Alpha3) && Input.GetKey(KeyCode.Alpha1))
        {
            bulletNum = 5;
            gun.sprite = GunName[5];
        }

        if (PauseManager.pause.isPaused == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AudioManager.instance.Play("Bullet");
                GameObject bullet = null;
                bullet = Spawner.Spawn(bulletColor[bulletNum]);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                bullet.GetComponent<BulletController>().Fire(dir.normalized);
            }
        }
        if (rainbowChip == 1 && RainActive == false)
        {
            AudioManager.instance.Play("Rainbow");
            StartCoroutine("Rainbow");
            rainbow.transform.position = player.transform.position;
            rainbow.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedAstro" && gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            GameManager.LifeLost();
        }
        if (collision.gameObject.tag == "BlueAstro" && gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            GameManager.LifeLost();
        }
        if (collision.gameObject.tag == "YellowAstro" && gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            GameManager.LifeLost();
        }
        if (collision.gameObject.tag == "PurpleAstro" && gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            GameManager.LifeLost();
        }
        if (collision.gameObject.tag == "GreenAstro" && gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            GameManager.LifeLost();
        }
        if (collision.gameObject.tag == "OrangeAstro" && gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            GameManager.LifeLost();
        }
    }
    IEnumerator Rainbow()
    {
        RainActive = true;
        rainbowChip = 0;
        rainbow = Spawner.Spawn("RainbowLazer");
        rainbow.SetActive(true);
        yield return new WaitForSeconds(10);
        rainbow.SetActive(false);
        AudioManager.instance.Stop("Rainbow");
        RainActive = false;

    }
}
