using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject difficutlyMenu;

    public void PlayGame()
    {
        mainMenu.gameObject.SetActive(false);
        difficutlyMenu.gameObject.SetActive(true);
    }

    public void BackButton()
    {        
        difficutlyMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }

    public void EasyButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MediumButton()
    {
        SceneManager.LoadScene(2);
    }

    public void HardButton()
    {
        SceneManager.LoadScene(3);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
