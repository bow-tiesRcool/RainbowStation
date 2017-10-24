using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public static DroneController drone;
    public float moveSpeed = 1f;
    Vector3 pos;
    Vector3 dir;
    float angle;
    public bool timeChip;
    public bool rainbowChip;
    public bool shieldChip;
    public bool explosionChip;
    GameObject Bomba;
    GameObject time;
    public bool BombaActive = false;

    private void Awake()
    {
        if (drone == null)
        {
            drone = this;
        }
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            pos = Camera.main.WorldToScreenPoint(transform.position);
            dir = Input.mousePosition - pos;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TimeChip" && PlayerController.player.RainActive == false)
        {
            collision.gameObject.SetActive(false);
            AudioManager.instance.Play("TimeWave");
            drone.timeChip = true;
            drone.time = Spawner.Spawn("TimeWave");
            drone.time.transform.position = PlayerController.player.transform.position;
            drone.time.SetActive(true);
            drone.StartCoroutine("Timertime");
            GameManager.instance.powerAmount--;
        }
        if (collision.gameObject.tag == "ShieldChip" && PlayerController.player.RainActive == false)
        {
            collision.gameObject.SetActive(false);
            GameManager.AddLife();
            GameManager.instance.powerAmount--;
        }
        if (collision.gameObject.tag == "RainbowChip" && PlayerController.player.RainActive == false)
        {
            collision.gameObject.SetActive(false);
            PlayerController.player.rainbowChip = 1;
            GameManager.instance.powerAmount--;
        }
        if (collision.gameObject.tag == "ExplosionChip" && BombaActive == false && PlayerController.player.RainActive == false)
        {
            drone.BombaActive = true;
            collision.gameObject.SetActive(false);
            AudioManager.instance.Play("ScreenBomb");
            drone.Bomba = Spawner.Spawn("Bomba");
            drone.Bomba.transform.position = PlayerController.player.transform.position;
            drone.Bomba.SetActive(true);
            StartCoroutine("Timer");
            GameManager.instance.powerAmount--;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        drone.Bomba.SetActive(false);
        drone.BombaActive = false;
    }
    IEnumerator PowerUpTime()
    {
        yield return new WaitForSeconds(10);
        drone.Bomba.SetActive(false);
        drone.time.SetActive(false);
        PlayerController.player.rainbow.SetActive(false);
    }
    IEnumerator Timertime()
    {
        yield return new WaitForSeconds(10);
        drone.timeChip = false;
    }
}