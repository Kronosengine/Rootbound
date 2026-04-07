using System.ComponentModel;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausePannel;
    [SerializeField] GameObject Pannel;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] Button Play;
    [SerializeField] Button Levels;
    [SerializeField] Button Restart;
    [SerializeField] Button Questions;
    [SerializeField] Button Settings;
    [SerializeField] Button MainMenu;

    private bool flag = false;
    private bool Open = false;

    void Start()
    {
        if (flag)
            PausePannel.SetActive(false);

        Play.onClick.AddListener(Begen_Play);
        Restart.onClick.AddListener(RestartLevel);
        MainMenu.onClick.AddListener(Go_Home);
        Levels.onClick.AddListener(Levels_Click);
        Questions.onClick.AddListener(Quest_Click);
        Settings.onClick.AddListener(Setting_Click);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!flag)
            {
                PausePannel.SetActive(true);
                Time.timeScale = 0f;
                flag = true;
            }
            else
            {
                Begen_Play();
            }
        }
    }

    void Begen_Play()
    {
        PausePannel.SetActive(false);
        Time.timeScale = 1f;
        flag = false;
    }

    void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1_1");
    }

    void Go_Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    void Levels_Click()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }
    async void Quest_Click()
    {
        Pannel.SetActive(true);
        await Quest_Show();
    }
    void Setting_Click()
    {
        SettingPanel.SetActive(true);
    }
    async Task Quest_Show()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pannel.SetActive(false);
                PausePannel.SetActive(true);
                Time.timeScale = 0f;
                break;
            }
            await Task.Yield();
        }
    }
}
