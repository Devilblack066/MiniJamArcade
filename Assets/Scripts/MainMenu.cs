using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainWindow;
    public GameObject CreditWindow;
    public void Play()
    {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Credit()
    {
        MainWindow.active = false;
        CreditWindow.active = true;
    }
    public void Return()
    {
        MainWindow.active = true;
        CreditWindow.active = false;
    }
}
