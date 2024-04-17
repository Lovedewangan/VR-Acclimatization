using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class waiting_timer : MonoBehaviour
{
    public float timer = 30f;
    public TextMeshProUGUI timerText;

    void Start()
    {
        UpdateTimerText();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log("Move to MRI room");
            // Optionally reset the timer here if needed
            // timer = 30f;
        }

        // Update the text display every frame
        UpdateTimerText();
    }

    // Update the text displayed in the TextMeshProUGUI object
    void UpdateTimerText()
    {
        // Format the timer value as minutes:seconds
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        // Update the TextMeshProUGUI text
        timerText.text = timeString;
    }
}
