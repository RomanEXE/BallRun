using TMPro;
using UnityEngine;
using YG;

public class CoinsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsTMP;
    
    private void OnEnable()
    {
        Actions.OnCoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        Actions.OnCoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _coinsTMP.text = $"Монеты: {YandexGame.savesData.Coins.ToString()}";
    }
}