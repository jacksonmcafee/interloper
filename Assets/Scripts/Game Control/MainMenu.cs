using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // swaps to Info scene
    public void OpenInfo()
    {
      SceneManager.LoadSceneAsync("Info");
    }

    // swaps to Level scene 
    public void OpenGame()
    {
      SceneManager.LoadSceneAsync("Stage 1");
    }

    // swaps to Settings scene 
    public void OpenSettings()
    {
      SceneManager.LoadSceneAsync("Settings");
    }

    // swaps to Menu scene 
    public void OpenMenu()
    {
      SceneManager.LoadSceneAsync("Menu");
    }

    // swaps to Credits scene 
    public void OpenCredits()
    {
      SceneManager.LoadSceneAsync("Credits");
    } 

    // exits game 
    public void CloseGame()
    {
      Application.Quit();
    }
}
