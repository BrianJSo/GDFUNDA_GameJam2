using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject MainPanel;
    public GameObject NarrationPanel;
    public GameObject InstructionPanel;

    private void Start()
    {
        
    }

    public void TriggerDialogue()
    {
        MainPanel.SetActive(false);
        NarrationPanel.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);        
    }

    public void closeNarration()
    {
        NarrationPanel.SetActive(false);
        InstructionPanel.SetActive(true);
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.TROPHY_INTERACTED);
    }
}
