using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenGame()
    {
      SceneManager.LoadSceneAsync("planettest");
    }

    public void OpenSettings()
    {
      SceneManager.LoadSceneAsync("Settings");
    }

    public void OpenMenu()
    {
      SceneManager.LoadSceneAsync("Menu");
    }

    public void OpenCredits()
    {
      SceneManager.LoadSceneAsync("Credits");
    } 

    public void CloseGame()
    {
      Application.Quit();
    }
}
