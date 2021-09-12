using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CologneBottle : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.COLOGNE_INTERACTED, this.TriggerDialogue);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        GameObject.Find("Perfume").GetComponent<MeshCollider>().enabled = false;
    }
}
