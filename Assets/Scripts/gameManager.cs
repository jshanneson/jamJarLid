using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool gameHasWon = false;
    public float restartDelay = 1f;
    public GameObject deathVideo;
    public GameObject winVideo;
    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            deathVideo.SetActive(true);

            //restart game
            Invoke("Restart", restartDelay);
        }      
    }

    public void WinGame ()
    {
        if (gameHasWon == false)
        {
            gameHasWon = true;
            winVideo.SetActive(true);

            //next level
            Invoke("NextLevel", restartDelay);
            
        }      
    }


    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}