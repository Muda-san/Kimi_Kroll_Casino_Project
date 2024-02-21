using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{




    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayLejeutmort()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void QuitTheGame()
    {
        Application.Quit();
    }
}
