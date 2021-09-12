using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectRaycast : MonoBehaviour
{

    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    private ObjectController rayCastedObj;
    
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

                Parameters animationParams = new Parameters();
                animationParams.PutExtra(GameEventNames.ITEM_NAME, rayCastedObj.GetItemName());

                switch (rayCastedObj.GetItemName())
                {
                    case "Trophy":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.TROPHY_INTERACTED);
                        EventBroadcaster.Instance.PostEvent(GameEventNames.ITEM_INTERACTED);
                        break;
                    case "Guitar":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.GUITAR_INTERACTED);
                        EventBroadcaster.Instance.PostEvent(GameEventNames.ITEM_INTERACTED);
                        break;
                    case "Poster":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.POSTER_INTERACTED);
                        EventBroadcaster.Instance.PostEvent(GameEventNames.ITEM_INTERACTED);
                        break;
                    case "Stuffed Bear":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.BEAR_INTERACTED);
                        EventBroadcaster.Instance.PostEvent(GameEventNames.ITEM_INTERACTED);
                        break;
                    case "Dog Stuff":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.DOG_INTERACTED);
                        EventBroadcaster.Instance.PostEvent(GameEventNames.ITEM_INTERACTED);
                        break;
                    case "Cologne":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.COLOGNE_INTERACTED);
                        EventBroadcaster.Instance.PostEvent(GameEventNames.ITEM_INTERACTED);
                        break;
                    case "Shoes":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.SHOES_INTERACTED);
                        EventBroadcaster.Instance.PostEvent(GameEventNames.ITEM_INTERACTED);
                        break;
                    case "Picture":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.PICTURE_INTERACTED);
                        EventBroadcaster.Instance.PostEvent(GameEventNames.ITEM_INTERACTED);
                        break;
                    case "Closet door":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.OPEN_ANIMATION_TRIGGER, animationParams);
                        break;
                    case "Folder":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.OPEN_ANIMATION_TRIGGER, animationParams);
                        break;
                    case "Drawer":
                        EventBroadcaster.Instance.PostEvent(GameEventNames.OPEN_ANIMATION_TRIGGER, animationParams);
                        break;

                }
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
