using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu_Buttons_Functions : MonoBehaviour
{
    public void Play_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit_Game()
    {
        Application.Quit();
    }
}
