using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // swaps to Level scene 
    public void OpenGame()
    {
      SceneManager.LoadSceneAsync("planettest");
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
