using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public string level;

    private void OnEnable()
    {
        StartCoroutine("NextLevel");
    }

    IEnumerator NextLevel()
    {
        Debug.Log(name);
        yield return new WaitForSeconds(2);
        while (enabled)
        {
            if (Input.GetButton("Fire1"))
            {
                SceneManager.LoadScene(level);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
