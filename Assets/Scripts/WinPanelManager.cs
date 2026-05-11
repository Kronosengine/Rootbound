using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelManager : MonoBehaviour
{
    // Сюда в инспекторе перетащи объект самой Визуальной Панели
    public GameObject visualPanel;

    // Перетащи сюда 3 объекта Звезд (в порядке: монеты, финиш, секретная)
    public GameObject[] starIcons = new GameObject[3];

    // Эти переменные будут меняться в процессе игры
    [HideInInspector] public bool collectedAllCoins = false;
    [HideInInspector] public bool finishedLevel = false;
    [HideInInspector] public bool collectedSecretStar = false;

    public void ShowWinPanel()
    {
        visualPanel.SetActive(true); // Включаем саму панель

        // Зажигаем звезды по критериям
        if (starIcons.Length >= 3)
        {
            // 1-я звезда: собраны все монеты
            if (collectedAllCoins && starIcons[0] != null)
                starIcons[0].SetActive(true);

            // 2-я звезда: пройден уровень (всегда true, но оставлю для логики)
            if (finishedLevel && starIcons[1] != null)
                starIcons[1].SetActive(true);

            // 3-я звезда: найдена секретная звезда на уровне
            if (collectedSecretStar && starIcons[2] != null)
                starIcons[2].SetActive(true);
        }

        Time.timeScale = 0f; // Пауза
    }

    // Команды для кнопок
    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            SceneManager.LoadScene("MainMenu");
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