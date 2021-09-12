using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{

    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    private ObjectController rayCastedObj;
    
    [SerializeField] private Image crosshair;
    private bool isCrosshairActive;
    private bool doOnce;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("InteractObject"))
            {
                if (!doOnce)
                {
                    rayCastedObj = hit.collider.gameObject.GetComponent<ObjectController>();
                    rayCastedObj.ShowObjectName();
                }
                isCrosshairActive = true;
                doOnce = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked: " + rayCastedObj.GetItemName());
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                rayCastedObj.HideObjectName();
                doOnce = false;
            }
           
        }
    }

}
