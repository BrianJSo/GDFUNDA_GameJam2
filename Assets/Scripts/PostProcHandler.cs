using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class PostProcHandler : MonoBehaviour
{

    [SerializeField] private PostProcessVolume blackAndWhite;
    private int colorCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.ITEM_INTERACTED, this.TriggerColor);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.ITEM_INTERACTED);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerColor()
    {
        switch(colorCounter){
            case 0:
                TurnOffProcessing(blackAndWhite);
                break;
            default:
                break;
        }
    }

    IEnumerator TurnOffProcessing(PostProcessVolume currVolume)
    {
        float timeElapsed = 0;
        float lerpDuration = 4;
        if (timeElapsed < lerpDuration)
        {
            currVolume.weight = Mathf.Lerp(1, 0, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        yield return null;
    }
}
