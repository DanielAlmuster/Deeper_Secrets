using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
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
}
