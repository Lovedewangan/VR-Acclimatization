using UnityEngine;

public class companion : MonoBehaviour
{

    public Transform player;
    public Transform targetPosition;
    public Transform targetPosition2;
    public Transform targetPosition3;
    public Transform targetPosition4;
    public Animator animator;
    private float movementSpeed = 2.0f;
    private bool reachedTarget2 = false;
    private bool reachedTarget3 = false;
    private bool InteractWithPlayer = false;
    private bool MoveTowardsPlayer = false;

    void Update()
    {
        if (waiting_timer.timer > 0)
        {
            if (waiting_to_MRI.check == 1)
            {
                animator.SetBool("MoveTowardsPlayer", true);
                animator.SetBool("InteractWithPlayer", false); // Corrected variable name
                transform.LookAt(targetPosition.position);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * movementSpeed);
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                animator.SetBool("InteractWithPlayer", true);
                transform.LookAt(player.position);
                animator.SetBool("MoveTowardsPlayer", false);

            }

        }
        else
        {
            
           // animator.SetBool("InteractWithPlayer", false);

            if (!reachedTarget2)
            {
                animator.SetBool("InteractWithPlayer", false);
                movementSpeed = 1.5f;
                //animator.SetBool("InteractWithPlayer", false);
                //animator.SetBool("MoveTowardsPlayer", true);
                transform.LookAt(targetPosition2.position);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition2.position, Time.deltaTime * movementSpeed);

                if (Vector3.Distance(transform.position, targetPosition2.position) < 0.1f)
                {
                    reachedTarget2 = true;
                    targetPosition2.gameObject.SetActive(false);
                    targetPosition2.position = targetPosition3.position;
                }
            }
            else if (!reachedTarget3)
            {

                movementSpeed = 1.5f;
                //animator.SetBool("InteractWithPlayer", false);
                //animator.SetBool("MoveTowardsPlayer", true);
                transform.LookAt(targetPosition3.position);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition3.position, Time.deltaTime * movementSpeed);
                if (Vector3.Distance(transform.position, targetPosition3.position) < 0.1f) // Corrected position check
                {
                    reachedTarget3 = true;
                }
            }
            else
            {
                
                movementSpeed = 1.5f;
                //animator.SetBool("MoveTowardsPlayer", true);
                transform.LookAt(targetPosition4.position);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition4.position, Time.deltaTime * movementSpeed);

                if (Vector3.Distance(transform.position, targetPosition4.position) < 0.1f)
                {
                    animator.SetBool("InteractWithPlayer", true);
                    transform.LookAt(player.position);
                }
            }
        }
    }

    void temp()
    {
        animator.SetBool("InteractWithPlayer", false); // Corrected variable name
    }
}
