using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAudio : MonoBehaviour {


    void Start()
    {
        AudioManager.instance.Play("Level");
    }

    private void OnDestroy()
    {
        AudioManager.instance.Stop("Level");
    }

}
