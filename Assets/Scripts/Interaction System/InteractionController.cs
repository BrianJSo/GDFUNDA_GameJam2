using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public InteractionInputData interactionInputData;
    public InteractionData interactionData;
    [SerializeField]private GameObject firstPersonCam;

    public float rayDistance;
    public float raySphereRadius;
    public LayerMask interactableLayer;

    private Camera cam;
    private bool interacting;
    private float holdTimer = 0f;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        CheckForInteractable();
        CheckForInteractableInput();
    }
    
    void CheckForInteractable()
    {
        Ray ray = new Ray(cam.transform.position, firstPersonCam.transform.forward);
        RaycastHit hitInfo;

        bool hitSomething = Physics.SphereCast(ray, raySphereRadius, out hitInfo, rayDistance, interactableLayer);

        if (hitSomething)
        {
            InteractableBase interactable = hitInfo.transform.GetComponent<InteractableBase>();
            Debug.Log(hitInfo.transform);
            if (interactable != null)
            {
                
                if (interactionData.IsEmpty())
                {
                    interactionData.SetInteractableBase(interactable);
                }
                else
                {
                    if (!interactionData.IsSameInteractable(interactable))
                    {
                        interactionData.SetInteractableBase(interactable);
                    }
                        
                }
            }
        }
        else
        {
            interactionData.Reset();
        }

        Debug.DrawRay(ray.origin, ray.direction * rayDistance , hitSomething ? Color.green : Color.red);
    }

    void CheckForInteractableInput()
    {
        if (interactionData.IsEmpty())
            return;
        if (interactionInputData.GetInteractedClicked() == true)
        {
            interacting = true;
            holdTimer = 0f;
        }
        if (interactionInputData.GetInteractedRelease() == true)
        {
            interacting = false;
            holdTimer = 0f;

        }
        if (interacting)
        {
            if (!interactionData.GetInteractableBase().IsInteractable)
                return;

            if (interactionData.GetInteractableBase().HoldInteract)
            {
                holdTimer += Time.deltaTime;
                if (holdTimer >= interactionData.GetInteractableBase().HoldDuration)
                {
                    interactionData.Interact();
                    interacting = false;
                }
            }
            else
            {
                interactionData.Interact();
                interacting = false;
            }
        }
    }
}
