using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainWindow;
    public GameObject CreditWindow;

    public AudioClip SoundBoutton;
    public void Play()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundBoutton);
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0);
    }
    public void Quit()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundBoutton);
        Application.Quit();
    }
    public void Credit()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundBoutton);
        MainWindow.active = false;
        CreditWindow.active = true;
    }
    public void Return()
    {
        GetComponent<AudioSource>().PlayOneShot(SoundBoutton);
        MainWindow.active = true;
        CreditWindow.active = false;
    }
}
