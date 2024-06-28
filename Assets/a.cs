using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public GameObject UI;
    // Start is called before the first frame update
    
    public void activate()
    {
        UI.gameObject.SetActive(false);
    }
}
