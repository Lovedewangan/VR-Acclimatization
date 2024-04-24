using UnityEngine;

public class xompanion : MonoBehaviour
{
    public Transform targetPosition;
    public Transform targetPosition2;
    public Transform targetPosition3;
    public Animator animator;
    public float movementSpeed = 2.0f;

    

    void Update()
    {
        if (waiting_timer.timer > 0)
        {
            if (waiting_to_MRI.check == 1)
            {
                animator.SetBool("MoveTowardsPlayer", true);
                transform.LookAt(targetPosition.position);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * movementSpeed);
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                animator.SetBool("InteractWithPlayer", true);
            }
        }
        else
        {
            animator.SetBool("InteractWithPlayer", false);
            //animator.SetBool("MoveTowardsPlayer", true);
            transform.LookAt(targetPosition2.position);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition2.position, Time.deltaTime * movementSpeed);
        }
        if(transform.position == targetPosition2.position)
        {
            //animator.SetBool("MoveTowardsPlayer", true);
            transform.LookAt(targetPosition3.position);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition3.position, Time.deltaTime * movementSpeed);

        }
    }
}
