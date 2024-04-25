using TMPro;
using UnityEngine;

public class companion2 : MonoBehaviour
{
    public Transform[] waypoints;   
    public float movementSpeed = 2.0f; 
    public float rotationSpeed = 5.0f; 

    private int currentWaypointIndex = 0;
    private Quaternion targetRotation;
    private Animator animator;
    private Transform targetPosition;
    private Transform targetPosition2;
    private Transform targetPosition3;

    void Start()
    {
    }

    void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No waypoints defined for the spider to follow.");
            return;
        }

        MoveTowardsWaypoint();

    }

    void MoveTowardsWaypoint()
    {
        if (waiting_timer.timer > 0)
        {
            if (waiting_to_MRI.check == 1)
            {
               // (currentWaypointIndex + 1);
                animator.SetBool("MoveTowardsPlayer", true);
                transform.LookAt(targetPosition);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * movementSpeed);

            }
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                animator.SetBool("InteractWithPlayer", true);
            }
        }
    }

    void SetTargetRotation()
    {
        // Set the target rotation based on the current waypoint index
        if (currentWaypointIndex == 0)
        {
            targetRotation = Quaternion.Euler(0, 90f, 0f);
        }
        else if (currentWaypointIndex == 8)
        {
            targetRotation = Quaternion.Euler(0f, 90f, -90f);
        }
        else if (currentWaypointIndex == 10)
        {
            targetRotation = Quaternion.Euler(0f, -90f, 180f);
        }
        else if (currentWaypointIndex == 17)
        {
            targetRotation = Quaternion.Euler(180f, 90f, 90f);
        }
    }
}
