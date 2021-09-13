using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deed : MonoBehaviour
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
        if(i < 6)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue1);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);
        }
        //GameObject.Find("Trophy").GetComponent<MeshCollider>().enabled = false;        
    }

    public void counter()
    {
        i++;
    }
}
