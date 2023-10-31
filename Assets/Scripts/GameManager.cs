using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public Text scoreText;
    //public Text timeText;
    public GameObject gameoverUI;
    //public AudioClip gameoverAudioSource;

    private int score = 0;
    private float time;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        /*if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
        }
    }
    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }

    public void offsound()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void ExitGame()
    {
         #if UNITY_EDITOR
              UnityEditor.EditorApplication.isPlaying = false;
         #else
              Application.Quit();
         #endif
    }


}
