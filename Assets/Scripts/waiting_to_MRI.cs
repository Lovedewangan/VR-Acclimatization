using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waiting_to_MRI : MonoBehaviour
{
    public GameObject timer_canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        timer_canvas.SetActive(true);
    }
}
