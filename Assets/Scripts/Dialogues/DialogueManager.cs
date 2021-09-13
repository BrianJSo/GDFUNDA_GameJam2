using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class DialogueManager : MonoBehaviour
{   
    public Text dialogueText;

    public Queue<string> sentences;

    public Animator animator;
    [SerializeField] public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();      

        //EventBroadcaster.Instance.AddObserver(GameEventNames.BEAR_INTERACTED, TeddyBear.TriggerDialogue());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }      
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        controller.GetComponent<FirstPersonController>().enabled = false;
        animator.SetBool("isOpen", true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
       
            DisplayNextSentence();        
    }
    
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        controller.GetComponent<FirstPersonController>().enabled = true;
        animator.SetBool("isOpen", false);
    }
}
