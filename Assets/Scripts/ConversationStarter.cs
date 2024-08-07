using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.XR;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject convoUIManager;
    [SerializeField] private AudioSource NPCSound;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the PrimaryIndexTrigger is pressed
        //if (IsPrimaryIndexTriggerPressed())
        //{
        convoUIManager.SetActive(true);
        NPCSound.Play();
        
        ConversationManager.Instance.StartConversation(myConversation);
        //}
    }
    private void OnTriggerExit(Collider other)
    {
        NPCSound.Stop();
        //convoUIManager.SetActive(false);
        Destroy(convoUIManager);
        Destroy(gameObject);
    }


    /* public bool IsPrimaryIndexTriggerPressed()
     {
         // Get the list of XR devices
         List<InputDevice> devices = new List<InputDevice>();
         InputDevices.GetDevices(devices);

         foreach (var device in devices)
         {
             // Check if the device has the PrimaryIndexTrigger
             if (device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
             {
                 // Check if the trigger value exceeds a threshold (e.g., 0.5 for half-pressed)
                 if (triggerValue > 0.1f)
                 {
                     return true;
                 }
             }
         }

         return false;
     }*/
}
