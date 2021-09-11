using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionInputData", menuName = "InteractionSystem/InputData")]
public class InteractionInputData : ScriptableObject
{
    private bool interactedClicked;
    private bool interactedRelease;

    public bool GetInteractedClicked()
    {
        return interactedClicked;
    }

    public void SetInteractedClicked(bool interactedClicked)
    {
        this.interactedClicked = interactedClicked;
    }

    public bool GetInteractedRelease()
    {
        return interactedRelease;
    }

    public void SetInteractedRelease(bool interactedRelease)
    {
        this.interactedRelease = interactedRelease;
    }

    public void Reset()
    {
        interactedClicked = false;
        interactedRelease = false;
    }
}
