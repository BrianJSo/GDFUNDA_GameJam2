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
        GameObject.Find("Shoes").GetComponent<BoxCollider>().enabled = false;
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.SHOES_INTERACTED);
    }
}
