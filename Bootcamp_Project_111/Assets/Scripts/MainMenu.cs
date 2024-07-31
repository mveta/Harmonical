using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject optionscanvas;
    public void play()
    {
        SceneManager.LoadScene("HomeCinematic");
    }
   
    public void options()
    {
        optionscanvas.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void HomeButton()
    {
        optionscanvas.SetActive(false);
    }
}
