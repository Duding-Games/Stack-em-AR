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
    private bool gameActive = true;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerTutorialText;
    public GameObject UITutorial;

    void Start()
    {
        timeRemaining = gameDuration;
        tutorialRemaining = tutorialDuration;
    }

    void Update()
    {
        if (gameActive)
        {
            tutorialRemaining -= Time.deltaTime;
            UpdateTutorialUI();
            if(tutorialRemaining <= 0)
            {
                UITutorial.SetActive(false);
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

    void EndGame()
    {
        gameActive = false;
        Debug.Log("Game Over!");
    }
}
