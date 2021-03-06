using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyPic : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.PICTURE_INTERACTED, this.TriggerDialogue);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        GameObject.Find("FamilyPicture").GetComponent<MeshCollider>().enabled = false;
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.PICTURE_INTERACTED);
    }
}
