using UnityEngine;
using UnityEngine.SceneManagement;

public class levelmanager : MonoBehaviour
{
    // Restart current scene
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Chest.ResetChestCount();
        Time.timeScale = 1f;
          Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
    }

    // Next scene
    public void nextscene()
    { Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Previous scene
    public void previousscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Quit game
    public void quitgame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}