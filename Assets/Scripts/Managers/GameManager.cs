using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coins = 0;
    public TextMeshProUGUI coinText; // сюда перетащим UI текст

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoin()
    {
        coins++;
        if (coinText != null)
            coinText.text = "Coins: " + coins;
    }
}
