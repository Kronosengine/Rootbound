using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause UI")]
    public GameObject pausePanel;  // панель с кнопками паузы
    private bool isPaused = false;

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false); // скрываем панель при старте
    }

    void Update()
    {
        // Открытие/закрытие паузы клавишей Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused) Pause();
            else Resume();
        }
    }

    public void Pause()
    {
        if (pausePanel == null) return;
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // останавливаем игру
        isPaused = true;
    }

    public void Resume()
    {
        if (pausePanel == null) return;
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // возобновляем игру
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // имя твоей сцены главного меню
    }
}