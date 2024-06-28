using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thumbnail_Manager : MonoBehaviour
{
    public GameObject videoPlayerScreen1;
    public GameObject videoPlayerScreen2;
    public GameObject videoPlayerScreen3;
    public GameObject thumbnail1;
    public GameObject thumbnail2;
    public GameObject thumbnail3;
    public GameObject play1;
    public GameObject play2;
    public GameObject play3;
    public void hide()
    {
        thumbnail1.gameObject.SetActive(false);
        thumbnail2.gameObject.SetActive(false);
        thumbnail3.gameObject.SetActive(false);
        play1.gameObject.SetActive(false);
        play2.gameObject.SetActive(false);
        play3.gameObject.SetActive(false);
        videoPlayerScreen1.SetActive(true);
        videoPlayerScreen2.SetActive(true);
        videoPlayerScreen3.SetActive(true);
    }

}
