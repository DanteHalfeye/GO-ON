using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapFps : MonoBehaviour
{
    public GameObject soundControl;
    bool count = false;
    void Awake()
    {
       
        Application.targetFrameRate = 60;
    }

   
    private void Update()
    {
     
        if (PauseMenu.GameIsPaused)
        {
            PauseGame();
        }
        if (PauseMenu.GameIsPaused == false)
        {
            ResumeGame();
        }

    }
   

    void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;

    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;

    }
}

