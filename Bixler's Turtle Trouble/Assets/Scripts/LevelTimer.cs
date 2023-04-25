using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public float timeRemaining = 90.0f; // Total time for the level in seconds
    public Text timerText; // Reference to a UI Text component for displaying the timer

    private void Update()
    {
        // Update the timer countdown
        timeRemaining -= Time.deltaTime;
        UpdateTimerUI();

        // Check if the timer has reached zero
        if (timeRemaining <= 0.0f)
        {
            // Perform game over logic, e.g., end the level, display a game over screen, etc.
            Debug.Log("Time's up!");
        }
    }

    private void UpdateTimerUI()
    {
        // Update the UI Text component with the current time remaining in minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60.0f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60.0f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
