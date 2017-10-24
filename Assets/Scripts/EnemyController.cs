using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController enemy;
    Rigidbody2D body;
    public float enemySpeed = 1;
    public int point = 10;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (DroneController.drone.timeChip == true)
        {
            enemySpeed = .5f;
        }
        if (DroneController.drone.timeChip == false)
        {
            enemySpeed = 1;
        }
        Vector2 target = (Vector2)PlayerController.player.transform.position;
        Vector2 heading = (target - (Vector2)transform.position).normalized;
        body.velocity = heading * enemySpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedBullet" && gameObject.tag == "RedAstro")
        {
            AudioManager.instance.Play("Explosion");
            SpawnPowerUp();
            GameManager.Points(point);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "BlueBullet" && gameObject.tag == "BlueAstro")
        {
            AudioManager.instance.Play("Explosion");
            SpawnPowerUp();
            GameManager.Points(point);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "YellowBullet" && gameObject.tag == "YellowAstro" || collision.gameObject.tag == "RainbowLazer")
        {
            AudioManager.instance.Play("Explosion");
            SpawnPowerUp();
            GameManager.Points(point);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "PurpleBullet" && gameObject.tag == "PurpleAstro" || collision.gameObject.tag == "RainbowLazer")
        {
            AudioManager.instance.Play("Explosion");
            SpawnPowerUp();
            GameManager.Points(point);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "GreenBullet" && gameObject.tag == "GreenAstro" || collision.gameObject.tag == "RainbowLazer")
        {
            AudioManager.instance.Play("Explosion");
            SpawnPowerUp();
            GameManager.Points(point);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "OrangeBullet" && gameObject.tag == "OrangeAstro" || collision.gameObject.tag == "RainbowLazer")
        {
            AudioManager.instance.Play("Explosion");
            SpawnPowerUp();
            GameManager.Points(point);
            gameObject.SetActive(false);
        }
    }

    void SpawnPowerUp()
    {
        if (Random.value < GameManager.instance.powerUpChance)
        {
            if (GameManager.instance.powerAmount <= 5)
            {
                AudioManager.instance.Play("Yay");
                GameManager.instance.DropPowerUp(transform.position);
            }
        }
    }
}
