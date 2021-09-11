using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interaction Data", menuName = "InteractionSystem/InteractionData")]
public class InteractionData: ScriptableObject
{
    private InteractableBase interactable;

    public InteractableBase GetInteractableBase()
    {
        return interactable;
    }

    public void SetInteractableBase(InteractableBase interactable)
    {
        this.interactable = interactable;
    }

    public void Interact()
    {
        interactable.OnInteract();
        Reset();
    }

    public bool IsSameInteractable(InteractableBase newInteractable)
    {
        return interactable == newInteractable;
    }

    public void Reset()
    {
        interactable = null;
    }

    public bool IsEmpty()
    {
        return interactable == null;
    }
}
