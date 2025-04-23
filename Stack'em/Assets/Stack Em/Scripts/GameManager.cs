using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 60f;
    public float tutorialDuration = 20f;
    public float tutorialRemaining;
    private float timeRemaining;
    public bool gameActive = false;
    private bool gamePlayed = false;
    private int points;
    private int highScore;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerTutorialText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public GameObject UITutorial;
    public GameObject Timer;
    public GameObject Score;
    public GameObject HighScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        timeRemaining = gameDuration;
        tutorialRemaining = tutorialDuration;
        UITutorial.SetActive(false);
        Timer.SetActive(false);
        Score.SetActive(false);
        HighScore.SetActive(false);
    }

    void Update()
    {
        if (gamePlayed)
        {
            tutorialRemaining -= Time.deltaTime;
            UpdateTutorialUI();
            if(tutorialRemaining <= 0)
            {
                if (!gameActive) ActivateGame();

                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();

                points = PlayerPrefs.GetInt("ObjectsInArea", 0);
               
                Debug.Log(points);
                UpdateScoreUI();
                UpdateHighScoreUI();

                if (timeRemaining <= 0)
                {
                    EndGame();
                }
            }
           
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
        }
    }

    void UpdateTutorialUI()
    {
        if(timerTutorialText != null)
        {
            timerTutorialText.text = "Tutorial Time: " + Mathf.Ceil(tutorialRemaining).ToString();
        }
    }

    void UpdateScoreUI()
    {
        if (Score != null)
        {
            ScoreText.text = Mathf.Ceil(points).ToString();
        }
    }

    void UpdateHighScoreUI()
    {
        if (HighScore != null)
        {
            HighScoreText.text = "HighScore: " + Mathf.Ceil(highScore).ToString();
        }
    }


    void EndGame()
    {
        Timer.SetActive(false);
        if (points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        UpdateScoreUI();
        gameActive = false;
        Debug.Log("Game Over!");
        SceneManager.LoadScene("SampleScene");
    }

    public void ActivateGame()
    {
        UITutorial.SetActive(false);
        Timer.SetActive(true);
        Score.SetActive(true);
        HighScore.SetActive(true);

        gameActive = true;
        Debug.Log("Game is now active");
    }

    public void PlayGame()
    {
        UITutorial.SetActive(true);

        gamePlayed = true;
    }
}
