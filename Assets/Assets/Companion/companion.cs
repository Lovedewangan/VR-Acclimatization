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
    private bool reachedTarget4 = false;
    private bool InteractWithPlayer = false;
    private bool MoveTowardsPlayer = false;
    private bool waitForPlayer = false;
    public GameObject door;

    void Update()
    {
        if (waiting_timer.timer <= 0)
        {
            door.gameObject.SetActive(false);
        }

        if (waiting_timer.timer > 0)
        {
            if (waiting_to_MRI.check == 1)
            {
                MoveTowards(targetPosition);
            }

            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                InteractWithPlayer1();
            }
        }
        else
        {
            if (!reachedTarget2)
            {
                MoveTowards(targetPosition2);
            }


            if (!reachedTarget2 && Vector3.Distance(transform.position, targetPosition2.position) < 0.1f)
            {
                reachedTarget2 = true;
                targetPosition2.gameObject.SetActive(false);

                StopMovement();
            }

            if (reachedTarget2 && !reachedTarget3 && PlayerReachedTarget(player, targetPosition2))
            {

                MoveTowards(targetPosition3);
            }


            if (!reachedTarget3 && Vector3.Distance(transform.position, targetPosition3.position) < 0.1f)
            {
                reachedTarget3 = true;

                StopMovement();
            }

            if (reachedTarget3 && !reachedTarget4 && PlayerReachedTarget(player, targetPosition3))
            {

                MoveTowards(targetPosition4);
            }

            if (!reachedTarget4 && Vector3.Distance(transform.position, targetPosition4.position) < 0.1f)
            {
                reachedTarget4 = true;
                InteractWithPlayer1();
            }
        }
    }

    void MoveTowards(Transform target)
    {
        animator.SetBool("MoveTowardsPlayer", true);
        animator.SetBool("InteractWithPlayer", false);
        transform.LookAt(target.position);
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * movementSpeed);
    }

    void InteractWithPlayer1()
    {
        animator.SetBool("InteractWithPlayer", true);
        transform.LookAt(player.position);
        animator.SetBool("MoveTowardsPlayer", false);
    }

    bool PlayerReachedTarget(Transform player, Transform target)
    {
        return Vector3.Distance(player.position, target.position) < 0.9f;
    }

    void StopMovement()
    {
        animator.SetBool("MoveTowardsPlayer", false);
        animator.SetBool("InteractWithPlayer", false);
        animator.SetBool("waitForPlayer", true);
        transform.LookAt(player.position);
    }

    void temp()
    {
        animator.SetBool("InteractWithPlayer", false);
    }
}