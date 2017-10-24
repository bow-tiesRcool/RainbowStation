using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    private IEnumerator Start()
    {     
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
        GameManager.instance.powerAmount--;
    }

}
