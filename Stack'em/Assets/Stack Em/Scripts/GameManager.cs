using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 60f;
    public float tutorialDuration = 20f;
    public float tutorialRemaining;
    private float timeRemaining;
    public bool gameActive = false;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerTutorialText;
    public TextMeshProUGUI ScoreText;
    public GameObject UITutorial;
    public GameObject Timer;
    public GameObject Score;

    void Start()
    {
        timeRemaining = gameDuration;
        tutorialRemaining = tutorialDuration;
        UITutorial.SetActive(false);
        Timer.SetActive(false);
    }

    void Update()
    {
        if (gameActive)
        {
            UITutorial.SetActive(true);
            tutorialRemaining -= Time.deltaTime;
            UpdateTutorialUI();
            if(tutorialRemaining <= 0)
            {
                UITutorial.SetActive(false);
                Timer.SetActive(true);
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();

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
        //blablabla blebleble blublublu
    }

    void EndGame()
    {
        gameActive = false;
        Debug.Log("Game Over!");
    }

    public void ActivateGame()
    {
        gameActive = true;
        Debug.Log("GAME IS NOW ACTIVE");
    }
}
