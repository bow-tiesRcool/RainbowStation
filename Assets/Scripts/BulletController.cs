using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float initialSpeed = 50;
    public float lifeSpan = 3;

    void Update()
    {
        OffScreenCheck();
    }

    public void Fire(Vector3 direction)
    {
        gameObject.SetActive(true);
        //AudioManager.PlayEffect("Laser_Shoot7", 1, 1);
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = direction * initialSpeed;
        StartCoroutine("LifecycleCoroutine");
    }

    IEnumerator LifecycleCoroutine()
    {
        yield return new WaitForSeconds(lifeSpan);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedAstro")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "BlueAstro")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "YellowAstro")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "PurpleAstro")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "GreenAstro")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "OrangeAstro")
        {
            gameObject.SetActive(false);
        }
    }
    void OffScreenCheck()
    {
        Vector3 view = Camera.main.WorldToViewportPoint(transform.position);
        if (view.x > 1)
        {
            gameObject.SetActive(false);
        }
        if (view.x < 0)
        {
            gameObject.SetActive(false);
        }
        if (view.y > 1)
        {
            gameObject.SetActive(false);
        }
        if (view.y < 0)
        {
            gameObject.SetActive(false);
        }

    }
}
