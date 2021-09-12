using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectController : MonoBehaviour
{
    [SerializeField] private Text objectnameUI;

    [SerializeField] private float onScreenTimer;
    [HideInInspector] public bool startTimer;
    private float timer;

    void Start()
    {
    }

    void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                startTimer = false;
            }
        }
    }

    public void ShowName(string objectName)
    {
        objectnameUI.text = objectName;
    }

    public void HideName()
    {
        objectnameUI.text = "";
    }

    public void ShowAdditionalInfo(string newInfo)
    {
        timer = onScreenTimer;
        startTimer = true;
    }

}
