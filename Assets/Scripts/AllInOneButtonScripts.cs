using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllInOneButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }

    public void toGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void closeGame()
    {
        Application.Quit();
    }
}
