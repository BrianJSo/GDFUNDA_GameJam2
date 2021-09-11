using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour, IInteractable
{
    public float holdDuration;
    public bool holdInteract;
    public bool multipleUse;
    public bool isInteractable;
    public float HoldDuration => holdDuration;

    public bool HoldInteract => holdInteract;

    public bool MultipleUse => multipleUse;

    public bool IsInteractable => isInteractable;

    public void OnInteract()
    {
        Debug.Log("INTERACTED: " + gameObject.name);
    }
}
