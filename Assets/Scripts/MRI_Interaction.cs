using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRI_Interaction : MonoBehaviour
{
    public GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MRI"))
        {
            Vector3 position = targetObject.transform.position;
            transform.position = position;
            Debug.Log("MRI Interaction");
        }
    }
}
