using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JordanShoes : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.SHOES_INTERACTED, this.TriggerDialogue);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
