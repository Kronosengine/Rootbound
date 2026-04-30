using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    // Сюда в инспекторе перетащи WinPanelManager
    public WinPanelManager manager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Критерий 1: Все монеты собраны?
            if (GameManager.instance != null)
                manager.collectedAllCoins = GameManager.instance.IsAllCoinsCollected();

            // Критерий 2: Пройден уровень (всегда true при касании финиша)
            manager.finishedLevel = true;

            // Критерий 3: Секретная звезда собирается где-то в другом месте

            // Показываем панель победы
            manager.ShowWinPanel();
        }
    }
}