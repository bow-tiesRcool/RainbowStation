using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public GameObject settingsMod, extraMod, buttonMod, tutMod, ship;

    public Text highScoreText;
    public int highScore;
    public string highScoreKey = "highScore";
    public Slider musicVolumeSlider, SFXVolumeSlider;

    public string musicVolumeKey = "Music";
    public string SFXVolumeKey = "SFX";


    [Range(0f, 1f)]
    public float SFXVolume, MusicVolume;

    void Start()
    {
        MusicVolume = PlayerPrefs.GetFloat(musicVolumeKey, 1);
        SFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 1);
        

        musicVolumeSlider.value = MusicVolume;
        

        SFXVolumeSlider.value = SFXVolume;



        AudioManager.instance.Play("MainMenu");
        Main();

        highScore = PlayerPrefs.GetInt(highScoreKey);

        highScoreText.text = "BEST: " + highScore.ToString();
    }

    public void Main()
    {
        ship.gameObject.SetActive(true);
        buttonMod.gameObject.SetActive(true);
        settingsMod.gameObject.SetActive(false);
        extraMod.gameObject.SetActive(false);
        tutMod.gameObject.SetActive(false);
    }

    public void AdjustMusicVolume(float newVolume)
    {
        MusicVolume = newVolume;
        PlayerPrefs.SetFloat(musicVolumeKey, newVolume);
    }
    public void AdjustSFXVolume(float newVolume)
    {
        SFXVolume = newVolume;
        PlayerPrefs.SetFloat(SFXVolumeKey, newVolume);
    }

    public void Settings()
    {
        buttonMod.gameObject.SetActive(false);
        settingsMod.gameObject.SetActive(true);
        extraMod.gameObject.SetActive(false);
        tutMod.gameObject.SetActive(false);
    }

    public void Extras()
    {
        buttonMod.gameObject.SetActive(false);
        settingsMod.gameObject.SetActive(false);
        extraMod.gameObject.SetActive(true);
        tutMod.gameObject.SetActive(false);
    }
    public void Tutorial()
    {
        ship.gameObject.SetActive(false);
        buttonMod.gameObject.SetActive(false);
        settingsMod.gameObject.SetActive(false);
        extraMod.gameObject.SetActive(false);
        tutMod.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    public void LoadScene(string _SceneName)
    {
        AudioManager.instance.Stop("MainMenu");
        SceneManager.LoadScene(_SceneName);
    }


}
