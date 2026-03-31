using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public GameObject panel;

    public void Show()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}