using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button Quit;
    [SerializeField] Button Play;
    [SerializeField] Button Settings;
    [SerializeField] GameObject SettingsPanel;
    //Button Shoping;

    void Start()
    {
        Quit.onClick.AddListener(ButtonQuit_Click);
        Play.onClick.AddListener(ButtonPlay_Click);
        Settings.onClick.AddListener(ButtonSettings_Click);
        //Shoping.onClick.AddListener(ButtonShop_Click);
    }

    void ButtonQuit_Click()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;  // Для редактора
        #else
                Application.Quit();  // Для собранной игры
        #endif
    }
    void ButtonPlay_Click()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    void ButtonSettings_Click()
    {
        SettingsPanel.SetActive(true);
    }
    //void ButtonShop_Click()
    //{
    //    SceneManager.LoadScene("Shop");
    //}
}