using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Start()
    {

    }
    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Stop("Theme");
        AudioManager.themePlaying = false;
        FindObjectOfType<AudioManager>().PlayLoop("PlayTheme");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("App Quit");
        Application.Quit();
    }

}
