using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame ()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

    public void Exit ()
    {
        Application.Quit();
    }

    public void PlayAgain ()
    {
        SceneManager.LoadScene(0);
    } 

}
