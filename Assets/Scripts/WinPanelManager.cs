using UnityEngine;

public class WinPanelManager : MonoBehaviour
{
    public GameObject starCoin;
    public GameObject starFinish;
    public GameObject starSecret;

    public bool collectedAllCoins;
    public bool finishedLevel;

    void OnEnable()
    {
        if (finishedLevel)
            starFinish.SetActive(true);

        if (collectedAllCoins)
            starCoin.SetActive(true);

        if (SecretStar.collected)
            starSecret.SetActive(true);
    }
}