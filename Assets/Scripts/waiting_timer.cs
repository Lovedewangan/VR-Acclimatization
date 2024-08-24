using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class waiting_timer : MonoBehaviour
{
    public GameObject breathingPanel;
    public static float timer = 28f; //62 //66f
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI instruct;
    public TextMeshProUGUI label;
    public TextMeshProUGUI breathText;
    public TextMeshProUGUI breathTimerText;

    private float breathingTimer = 0f;
    private int breathingStage = 0; // 0: Breath in, 1: Hold, 2: Breath out
    [SerializeField] AudioClip MovingClip;
    [SerializeField] AudioClip MotivateClip;
    bool motivate = false;
    [SerializeField] AudioSource audio_source;

    void Start()
    {
        breathingPanel.gameObject.SetActive(false);
        UpdateTimerText();
    }

    void Update()
    {


        if (timer > 0)
        {
           

            timer -= Time.deltaTime;

            // Show breathing panel and perform breathing exercise when timer reaches certain value
            if (timer <= 19) //57 
            {
                //if(timer<=9 && motivate == false) { motivate = true; audio_source.PlayOneShot(MotivateClip, 1F); } //26
                breathingPanel.gameObject.SetActive(true);
                PerformBreathingExercise();
            }



            // Timer reached zero, move to MRI room
            if (timer <= 0)
            {
                audio_source.PlayOneShot(MovingClip, 1F);
                breathingPanel.gameObject.SetActive(false);
                Debug.Log("Move to MRI room");
                // Optionally reset the timer here if needed
                // timer = 30f;
            }

            // Update the text display every frame
            UpdateTimerText();
        }
        else
        {
            // Optionally hide timer and labels when timer reaches zero
            timerText.gameObject.SetActive(false);
            label.gameObject.SetActive(false);
            instruct.gameObject.SetActive(true);
        }


    }

    // Perform 4-7-8 breathing exercise
    void PerformBreathingExercise()
    {
        if (breathingTimer <= 0f)
        {
            switch (breathingStage)
            {
                case 0:
                    breathText.text = "Breath In";
                    breathingTimer = 4f; // Breath in for 4 seconds
                    break;
                case 1:
                    breathText.text = "   Hold";
                    breathingTimer = 7f; // Hold for 7 seconds
                    break;
                case 2:
                    breathText.text = "Breath Out";
                    breathingTimer = 8f; // Breath out for 8 seconds
                    break;
            }

            breathingStage = (breathingStage + 1) % 3; // Cycle through stages
        }
        else
        {
            breathingTimer -= Time.deltaTime;
            breathTimerText.text = Mathf.CeilToInt(breathingTimer).ToString(); // Update breath timer text
        }
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
