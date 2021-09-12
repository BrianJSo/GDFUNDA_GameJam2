using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogToy : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.DOG_INTERACTED, this.TriggerDialogue);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        GameObject.Find("DogStuff").GetComponent<BoxCollider>().enabled = false;
    }
}
