using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionInputHandler : MonoBehaviour
{
    public InteractionInputData interactionInputData;
    // Start is called before the first frame update
    void Start()
    {
        interactionInputData.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        GetInteractionInputData();
    }

    void GetInteractionInputData()
    {
        interactionInputData.SetInteractedClicked(Input.GetKeyDown(KeyCode.E));
        interactionInputData.SetInteractedRelease(Input.GetKeyUp(KeyCode.E));
    }
}
