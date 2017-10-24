using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject gameOverUI;
    public Text scoreUI;
    public Text highScoreUI;
    public string Player = "Player";
    public string[] PowerUpPrefabNames;
    public int score = 0;
    public int highScore;
    public int lives = 3;
    public float powerUpChance = 0.1f;
    public string scene;
    public GameObject power;
    public int powerAmount = 0;



    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1f;


        Spawner.spawner.StartCoroutine("StartSpawnEnemiesCoroutine");
        Spawner.spawner.StartCoroutine("SubtractTime");
        instance.scoreUI.text = "Score: " + instance.score;
        instance.highScoreUI.text = "HighScore: " + PlayerPrefs.GetInt("highScore");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             PauseManager.pause.isPaused = PauseManager.pause.togglePause();
        }
        HighScore();
    }

    public static void GameOver()
    {
        Debug.Log("you lost");
        instance.gameOverUI.SetActive(true);
        HighScoreSaver();
        AudioManager.instance.Stop("Yay");
    }

    public static void Points(int points)
    {
        int score = points;
        instance.score += score;
        instance.scoreUI.text = "Score: " + instance.score;
    }

    public static void HighScore()
    {
        if (instance.score > instance.highScore)
        {
            instance.highScore = instance.score;
        }
        if (instance.highScore > PlayerPrefs.GetInt("highScore"))
        {
            instance.highScoreUI.text = "highScore: " + instance.highScore;
        }
    }
    public static void HighScoreSaver()
    {
        if (PlayerPrefs.HasKey("highScore") == true)
        {
            if (instance.highScore > PlayerPrefs.GetInt("highScore"))
            {
                int newHighScore = instance.highScore;
                PlayerPrefs.SetInt("highScore", newHighScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            int newHighScore = instance.highScore;
            PlayerPrefs.SetInt("highScore", newHighScore);
            PlayerPrefs.Save();
        }
    }

    public static void LifeLost()
    {
        instance.lives = instance.lives - 1;
        
        if (instance.lives == 3)
        {
            PlayerController.player.shield.color = Color.green;
            AudioManager.instance.Play("Asteroid");

        }
        else if (instance.lives == 2)
        {
            PlayerController.player.shield.color = Color.yellow;
            AudioManager.instance.Play("Asteroid");

        }
        else if (instance.lives == 1)
        {
            PlayerController.player.shield.color = Color.red;
            AudioManager.instance.Play("Asteroid");

        }
        else if (instance.lives == 0)
        {
            AudioManager.instance.Play("ShieldDown");
            PlayerController.player.shield.color = Color.clear;
        }
        else
        {
            AudioManager.instance.Play("Dead");
            AudioManager.instance.Stop("Yay");
            PlayerController.player.playerPre.SetActive(false);
            GameObject Bomba = Spawner.Spawn("Death");
            Bomba.transform.position = PlayerController.player.transform.position;
            Bomba.SetActive(true);
            GameOver();
        }
    }

    public void DropPowerUp(Vector3 pos)
    {
        Debug.Log("Spawning PowerUp");
        string PowerUpPrefabName = PowerUpPrefabNames[Random.Range(0, PowerUpPrefabNames.Length)];

        power = Spawner.Spawn(PowerUpPrefabName);

        power.transform.position = pos;
        power.SetActive(true);
        DroneController.drone.StartCoroutine("PowerUpTime");
        powerAmount++;
        
    }

    public static void AddLife()
    {
        if (instance.lives < 5)
        {
            instance.lives = instance.lives + 1;
        }
        if (instance.lives == 3)
        {
            PlayerController.player.shield.color = Color.green;
        }
        else if (instance.lives == 2)
        {
            PlayerController.player.shield.color = Color.yellow;
        }
        else if (instance.lives == 1)
        {
            PlayerController.player.shield.color = Color.red;
        }
        else if (instance.lives == 0)
        {
            PlayerController.player.shield.color = Color.clear;
        }
        else
        {
            Debug.Log("Max Lives");
        }
    }
}
