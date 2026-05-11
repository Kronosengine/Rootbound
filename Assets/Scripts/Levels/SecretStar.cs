using UnityEngine;

public class SecretStar : MonoBehaviour
{
    public WinPanelManager manager; // Перетащи сюда WinPanelManager из инспектора

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Правильное обращение к переменной через manager
            manager.collectedSecretStar = true;
            gameObject.SetActive(false); // Спрятать звезду после сбора
        }
    }
}