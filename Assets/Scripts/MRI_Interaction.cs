using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MRI_Interaction : MonoBehaviour
{
    public LocomotionSystem locomotionSystem;
    public TeleportationProvider teleportationProvider;
    public ContinuousMoveProviderBase continuousMoveProvider;
    public SnapTurnProviderBase snapTurnProvider;


    public AudioSource audioMRIEnterandExit;
    public AudioSource audioSource;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject targetObject;
    public GameObject targetReached;
    public GameObject targetExit;
    public GameObject mriUI;
    public GameObject mriInsideUI;
    public GameObject mriExitUI;
    public bool activateUpdate = false;
    public bool mriExitUpdate = false;
    public float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        locomotionSystem = FindObjectOfType<LocomotionSystem>(); // Find the LocomotionSystem in the scene
        teleportationProvider = FindObjectOfType<TeleportationProvider>();
        continuousMoveProvider = FindObjectOfType<ContinuousMoveProviderBase>();
        snapTurnProvider = FindObjectOfType<SnapTurnProviderBase>();


        if (locomotionSystem == null)
        {
            Debug.LogError("LocomotionSystem not found in the scene.");
        }

        if (teleportationProvider == null)
        {
            Debug.LogError("TeleportationProvider not found in the scene.");
        }

        if (continuousMoveProvider == null)
        {
            Debug.LogError("ContinuousMoveProvider not found in the scene.");
        }
        if (snapTurnProvider == null)
        {
            Debug.LogError("SnapTurnProvider not found in the scene.");
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        

        if (activateUpdate)
        {

            if (locomotionSystem != null) locomotionSystem.enabled = false;
            if (teleportationProvider != null) teleportationProvider.enabled = false;
            if (continuousMoveProvider != null) continuousMoveProvider.enabled = false;
            if (snapTurnProvider != null) snapTurnProvider.enabled = false;

            

            Debug.Log("Activated");

            

            // Calculate the direction to move towards the targetObject
            Vector3 direction = (targetReached.transform.position - transform.position).normalized;

            float distanceToMove = moveSpeed * Time.deltaTime * 0.1f;
            // Move the GameObject towards the targetObject
            transform.position = Vector3.MoveTowards(transform.position, targetReached.transform.position, distanceToMove);

            // Check if the GameObject is close enough to the targetObject
            /* if (Vector3.Distance(transform.position, targetObject.transform.position) < 0.1f)w
            {
                // If close enough, stop moving and deactivate the Update function
                transform.position = targetReached.transform.position;
                activateUpdate = false;
                Debug.Log("DeActivated");
            }*/
            if (transform.position == targetReached.transform.position)
            {
                mriInsideUI.gameObject.SetActive(true);
                activateUpdate = false; // Deactivate the Update function
                Debug.Log("DeActivated");

                audioSource.Play();

                //Video Player Screens Just to hide previous video screens while selecting the video
                screen1.gameObject.SetActive(false);
                screen2.gameObject.SetActive(false);
                screen3.gameObject.SetActive(false);
                StartCoroutine(ShowExitUIDelayed());
            }

            // Calculate the distance to move this frame


            // Move the GameObject towards the targetObject


            // Check if the GameObject has reached the targetObject

        }
        if (mriExitUpdate)
        {
            audioMRIEnterandExit.Play();
            Debug.Log("ExitStarted");
            // Calculate the direction to move towards the targetObject
            Vector3 direction = (targetObject.transform.position - transform.position).normalized;

            float distanceToMove = moveSpeed * Time.deltaTime * 0.1f;
            // Move the GameObject towards the targetObject
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, distanceToMove);

            // Check if the GameObject is close enough to the targetObject
            /* if (Vector3.Distance(transform.position, targetObject.transform.position) < 0.1f)w
            {
                // If close enough, stop moving and deactivate the Update function
                transform.position = targetReached.transform.position;
                activateUpdate = false;
                Debug.Log("DeActivated");
            }*/
            if (transform.position == targetObject.transform.position)
            {
                if (locomotionSystem != null) locomotionSystem.enabled = true;
                if (teleportationProvider != null) teleportationProvider.enabled = true;
                if (continuousMoveProvider != null) continuousMoveProvider.enabled = true;
                if (snapTurnProvider != null) snapTurnProvider.enabled = true;

                mriExitUpdate = false;
                Debug.Log("ExitedMRI");

                Vector3 position = targetExit.transform.position;
                transform.position = position;
                transform.rotation = targetExit.transform.rotation;
            }

            // Calculate the distance to move this frame


            // Move the GameObject towards the targetObject


            // Check if the GameObject has reached the targetObject

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MRI"))
        {
            Vector3 position = targetObject.transform.position;
            transform.position = position;
            transform.rotation = targetObject.transform.rotation;
            Debug.Log("MRI Interaction");
            mriUI.gameObject.SetActive(true);
            other.gameObject.SetActive(false);


        }
        

    }


    
    public void ActivateMRIMovement()
    {
        audioMRIEnterandExit.Play();
        activateUpdate = true;
        mriUI.gameObject.SetActive(false);
    }
    
    /*public void ExitMRI()
    {
        mriExitUpdate = true;
        mriExitUI.gameObject.SetActive(false);
        mriInsideUI.gameObject.SetActive(false);
    }
    */
    IEnumerator ShowExitUIDelayed()
    {
        yield return new WaitForSeconds(120f); // Adjust the delay time as needed

        mriExitUpdate = true;
        mriInsideUI.gameObject.SetActive(false);
        audioMRIEnterandExit.Play();
        //mriExitUI.SetActive(true);
    }

    // To Enable and Disable the Joysticks
     

}
