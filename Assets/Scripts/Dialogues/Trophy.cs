using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.TROPHY_INTERACTED, this.TriggerDialogue);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        GameObject.Find("Trophy").GetComponent<MeshCollider>().enabled = false;        
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.TROPHY_INTERACTED);
    }
}
