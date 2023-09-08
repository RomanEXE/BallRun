using TMPro;
using UnityEngine;
using YG;

public class CoinsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsTMP;
    
    private void OnEnable()
    {
        Actions.OnCoinCollected += OnCoinCollected;
        Actions.OnSkinBought += delegate(Skin skin) { OnCoinCollected(); };
        YandexGame.GetDataEvent += OnCoinCollected;
    }

    private void OnDisable()
    {
        Actions.OnCoinCollected -= OnCoinCollected;
        YandexGame.GetDataEvent -= OnCoinCollected;
    }
    

    private void OnCoinCollected()
    {
        _coinsTMP.text = $"Монеты: {YandexGame.savesData.Coins.ToString()}";
    }
}