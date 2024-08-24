using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Illustration_Manager : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    [SerializeField] private GameObject illustrationUIManager;
    public float time;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ShowExitUIDelayed());
        //}
    }
    private void OnTriggerExit(Collider other)
    {

        illustrationUIManager.SetActive(false);
        Destroy(illustrationUIManager);
        Destroy(videoPlayer);

        
    }
    IEnumerator ShowExitUIDelayed()
    {
        yield return new WaitForSeconds(time); // Adjust the delay time as needed
        illustrationUIManager.SetActive(true);
        videoPlayer.Play();
        //mriExitUI.SetActive(true);
    }
}
