using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject restartMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject loseMenu;
    public bool isPaused = false;
    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        pauseMenu.SetActive(false);
        restartMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void QuitRestart()
    {
        restartMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ConfirmRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Win()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Lose()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
