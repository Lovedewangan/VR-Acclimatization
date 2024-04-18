using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRI_Interaction : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject targetReached;
    private bool activateUpdate = false;
    public float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activateUpdate)
        {
            Debug.Log("Activated");
            // Calculate the direction to move towards the targetObject
            Vector3 direction = (targetReached.transform.position - transform.position).normalized;

            float distanceToMove = moveSpeed * Time.deltaTime * 0.1f;
            // Move the GameObject towards the targetObject
            transform.position = Vector3.MoveTowards(transform.position, targetReached.transform.position, distanceToMove);

            // Check if the GameObject is close enough to the targetObject
            /* if (Vector3.Distance(transform.position, targetObject.transform.position) < 0.1f)
            {
                // If close enough, stop moving and deactivate the Update function
                transform.position = targetReached.transform.position;
                activateUpdate = false;
                Debug.Log("DeActivated");
            }*/
            if (transform.position == targetReached.transform.position)
            {
                activateUpdate = false; // Deactivate the Update function
                Debug.Log("DeActivated");
            }

            // Calculate the distance to move this frame


            // Move the GameObject towards the targetObject


            // Check if the GameObject has reached the targetObject

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MRI"))
        {
            Vector3 position = targetObject.transform.position;
            transform.position = position;
            transform.rotation = targetObject.transform.rotation;
            Debug.Log("MRI Interaction");
            activateUpdate = true;
            
        }
    }
    
}
