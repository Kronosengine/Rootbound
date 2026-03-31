using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadMainMenu", 1.5f); // задержка 1.5 секунды
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}