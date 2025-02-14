using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene("Basement");
    }

    public void SalirButton()
    {
        Application.Quit();
    }

    public void VolverButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
