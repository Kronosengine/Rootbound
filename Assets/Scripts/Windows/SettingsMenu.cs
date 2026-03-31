using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject settingsPanel; // панель настроек
    public Slider volumeSlider;      // слайдер громкости

    private AudioSource musicSource;

    void Start()
    {
        // Проверяем, что панель назначена
        if (settingsPanel == null)
            Debug.LogError("Settings Panel не назначена в инспекторе!");

        // Проверяем, что слайдер назначен
        if (volumeSlider == null)
            Debug.LogError("Volume Slider не назначен в инспекторе!");

        // Ищем MusicManager
        MusicManager musicManager = FindObjectOfType<MusicManager>();
        if (musicManager == null)
        {
            Debug.LogError("MusicManager не найден на сцене!");
            return;
        }

        musicSource = musicManager.GetComponent<AudioSource>();
        if (musicSource == null)
        {
            Debug.LogError("AudioSource не найден на MusicManager!");
            return;
        }

        // Синхронизируем слайдер с текущей громкостью
        if (volumeSlider != null)
            volumeSlider.value = musicSource.volume;

        // Подписываемся на изменение слайдера
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(SetVolume);

        // Скрываем панель настроек по умолчанию
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
    }

    public void SetVolume(float value)
    {
        if (musicSource != null)
        {
            musicSource.volume = value;
            PlayerPrefs.SetFloat("MusicVolume", value);
        }
    }

    public void OpenAbout()
    {
        Application.OpenURL("https://yourgamewebsite.com");
    }
}