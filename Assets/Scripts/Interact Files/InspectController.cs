using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InspectController : MonoBehaviour
{
    [SerializeField] private Text objectnameUI;

    [SerializeField] private float onScreenTimer;
    [SerializeField] private Text extraInfoUI;
    [SerializeField] private GameObject extranInfoBG;
    [HideInInspector] public bool startTimer;
    private float timer;

    void Start()
    {
        extranInfoBG.SetActive(false);
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
        extranInfoBG.SetActive(true);
        extraInfoUI.text = newInfo;
    }

    public void CleanAdditionalInfo()
    {
        extranInfoBG.SetActive(false);
        extraInfoUI.text = "";
    }
}
