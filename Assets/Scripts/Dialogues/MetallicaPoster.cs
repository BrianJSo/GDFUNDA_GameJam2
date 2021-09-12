using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetallicaPoster : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.POSTER_INTERACTED, this.TriggerDialogue);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
