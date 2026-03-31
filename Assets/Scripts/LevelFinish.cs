using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public GameObject winPanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}