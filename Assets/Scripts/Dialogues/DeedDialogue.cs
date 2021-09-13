using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeedDialogue : MonoBehaviour
{
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public static int i = 0;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.ITEM_INTERACTED, counter);
        EventBroadcaster.Instance.AddObserver(GameEventNames.DEED_INTERACTED, this.TriggerDialogue);
    }

    public void TriggerDialogue()
    {
        Debug.Log("dialogue triggered");
        if (i < 6)
        {
            Debug.Log("Pre 6 dialogue" + dialogue1.sentences[0]);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue1);
            Debug.Log("Pre 6 dialogue" + dialogue1.sentences[0]);
        }
        else
        {
            Debug.Log("Post 6 dialogue");
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);
        }
    }

    public void counter()
    {
        i++;
    }
    
    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.ITEM_INTERACTED);
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.DEED_INTERACTED);
    }
}
