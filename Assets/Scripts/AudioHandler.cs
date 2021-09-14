using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource gameMusic;
    private int audioCounter;

    void Start()
    {
        EventBroadcaster.Instance.AddObserver(GameEventNames.ITEM_INTERACTED, this.PlayAudio);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(GameEventNames.ITEM_INTERACTED);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayAudio()
    {
        audioCounter++;
        switch (audioCounter){
            case 5:
                gameMusic.Play();
                break;
            default:
                break;

        }
        
    }
}
