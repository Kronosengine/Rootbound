using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Загрузка уровня
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Кнопка назад в главное меню
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}