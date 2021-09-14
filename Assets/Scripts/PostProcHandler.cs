using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class PostProcHandler : MonoBehaviour
{

    [SerializeField] private PostProcessVolume blackAndWhite;
    [SerializeField] private PostProcessVolume color1;
    [SerializeField] private PostProcessVolume color2;
    [SerializeField] private PostProcessVolume color3;
    [SerializeField] private PostProcessVolume color4;
    [SerializeField] private PostProcessVolume color5;
    [SerializeField] private PostProcessVolume color6;
    [SerializeField] private PostProcessVolume all;
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
                StartCoroutine(TurnOffProcessing(blackAndWhite));
                break;
            case 1:
                StartCoroutine(TurnOffProcessing(color1));
                break;
            case 2:
                StartCoroutine(TurnOffProcessing(color2));
                break;
            case 3:
                StartCoroutine(TurnOffProcessing(color3));
                break;
            case 4:
                StartCoroutine(TurnOffProcessing(color4));
                break;
            case 5:
                StartCoroutine(TurnOffProcessing(color5));
                break;
            case 6:
                StartCoroutine(TurnOffProcessing(color6));
                break;
            default:
                break;
        }
        colorCounter++;
    }

    IEnumerator TurnOffProcessing(PostProcessVolume currVolume)
    {
        float timeElapsed = 0;
        float lerpDuration = 4;
        while (timeElapsed < lerpDuration)
        {
            currVolume.weight = Mathf.Lerp(1, 0, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            
            yield return null;
        }

        yield return null;
    }
}
