using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playLocal()
    {

    }
    public void playOnline()
    {

    }
    public void options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void quit()
    {
        Application.Quit();
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
