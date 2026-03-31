using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip menuMusic;
    public AudioClip levelMusic;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();

        // днаюбэ щрн
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Boot")
        {
            audioSource.Stop();
        }
        else if (scene.name == "MainMenu" || scene.name == "LevelSelect")
        {
            PlayMusic(menuMusic);
        }
        else
        {
            PlayMusic(levelMusic);
        }
    }


    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip) return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void RestartMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.time = 0f;
            audioSource.Play();
        }
    }
    public void PlayMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
