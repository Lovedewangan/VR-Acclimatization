using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private typeWriterEffect typewritereffect;

    private void Start()
    {

        typewritereffect = GetComponent<typeWriterEffect>();
        CloseDialogueBox();
        ShowDIalogue(testDialogue);
    }

    public void ShowDIalogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        yield return new WaitForSeconds(.5f); //2

        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewritereffect.Run(dialogue, textLabel);
            //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));  //replace with VR button here, cannot check now since fn I/P sys is diff 
        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
