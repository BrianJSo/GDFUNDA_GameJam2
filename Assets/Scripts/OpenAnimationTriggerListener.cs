using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAnimationTriggerListener : MonoBehaviour
{
    //[SerializeField] private string eventName;
    [SerializeField] private Animator animator;
    [SerializeField] private ObjectController thisObjectController;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        EventBroadcaster.Instance.AddObserver(GameEventNames.OPEN_ANIMATION_TRIGGER, this.AnimateOpening);
    }

    void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.OPEN_ANIMATION_TRIGGER);
    }
    private void AnimateOpening(Parameters parameters)
    {
        string triggeredItemName = parameters.GetStringExtra(GameEventNames.ITEM_NAME, "itemName");
        if(thisObjectController.GetItemName() == triggeredItemName && !isOpen)
        {
            thisObjectController.GetComponent<BoxCollider>().enabled = false;
            animator.Play("OpenAnimation", 0, 0.0f);
            isOpen = true;
        }
    }
}
