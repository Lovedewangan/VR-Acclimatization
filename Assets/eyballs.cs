using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyballs : MonoBehaviour
{
    public GameObject targ;
    private Animator targetAnimator;

    void Start()
    {
        if (targ != null)
        {
            targetAnimator = targ.GetComponent<Animator>();
            if (targetAnimator == null)
            {
                Debug.LogWarning("Target game object does not have an Animator component.");
            }
        }
        else
        {
            Debug.LogWarning("Target game object is not assigned.");
        }
    }

    void Update()
    {
        if (targ != null)
        {
            // Smoothly interpolate the position of the eyeballs to follow the target
            transform.position = Vector3.Lerp(transform.position, targ.transform.position, 0.1f);
        }
    }
}
