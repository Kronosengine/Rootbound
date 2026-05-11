using TMPro;
using UnityEngine;
using UnityEngine.UI; // Обязательно для работы с Text
// или используй "using TMPro;" если у тебя TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Настройки")]
    public TMP_Text coinText; // Перетащи сюда свой объект текста из Canvas

    public int collectedCoins = 0;
    private int totalCoinsInLevel;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        // Считаем монеты на уровне
        totalCoinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;

        // Сбрасываем счетчик при старте и обновляем визуально
        UpdateCoinUI();
    }

    public void AddCoin()
    {
        collectedCoins++;
        UpdateCoinUI(); // Обновляем текст каждый раз, когда подняли монету
    }

    // Метод для обновления текста на экране
    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            // Формат "Собрано / Всего" (например, 5 / 10)
            coinText.text = collectedCoins.ToString() + " / " + totalCoinsInLevel.ToString();

            // Если тебе нужно просто число собранных, оставь так:
            // coinText.text = collectedCoins.ToString();
        }
    }

    public bool IsAllCoinsCollected()
    {
        return collectedCoins >= totalCoinsInLevel && totalCoinsInLevel > 0;
    }
}