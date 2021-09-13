using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeedDialogue : MonoBehaviour
{
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public static int keyInteracted = 0;
    public static bool DeedInteracted = false;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.ITEM_INTERACTED, counter);
        EventBroadcaster.Instance.AddObserver(GameEventNames.DEED_INTERACTED, this.TriggerDialogue);
    }

    public void TriggerDialogue()
    {       
        if (keyInteracted < 6)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue1);            
        }
        else
        {
            DeedInteracted = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);
        }
    }

    public void counter()
    {
        keyInteracted++;
    }
    
    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.ITEM_INTERACTED);
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.DEED_INTERACTED);
    }
}
