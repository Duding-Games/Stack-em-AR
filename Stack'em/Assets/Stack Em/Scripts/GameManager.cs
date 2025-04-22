using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameDuration = 60f;
    private float timeRemaining;
    private bool gameActive = true;

    public TextMeshProUGUI timerText;

    void Start()
    {
        timeRemaining = gameDuration;
    }

    void Update()
    {
        if (gameActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();

            if (timeRemaining <= 0)
            {
                EndGame();
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

    void EndGame()
    {
        gameActive = false;
        Debug.Log("Game Over!");
    }
}
