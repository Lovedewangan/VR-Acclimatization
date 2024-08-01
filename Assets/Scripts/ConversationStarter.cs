using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.XR;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private void OnTriggerStay(Collider other)
    {
        // Check if the PrimaryIndexTrigger is pressed
        //if (IsPrimaryIndexTriggerPressed())
        //{
            ConversationManager.Instance.StartConversation(myConversation);
        //}
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
