using UnityEngine;
using YG;

public class CoinsCounter : MonoBehaviour
{
    private static CoinsCounter _instance;
    public static CoinsCounter Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<CoinsCounter>();
            
            return _instance;
        }
    }
    public int Coins;

    private void OnEnable()
    {
        Actions.OnCoinCollected += CollectCoin;
        Actions.OnGameEnd += delegate { YandexGame.savesData.Coins += Coins; };
    }

    private void OnDisable()
    {
        Actions.OnCoinCollected -= CollectCoin;
    }

    private void CollectCoin()
    {
        Coins++;
    }
}