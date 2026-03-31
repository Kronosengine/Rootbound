using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //  нопка Play
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //  нопка Quit
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); // работает только в редакторе
    }
}