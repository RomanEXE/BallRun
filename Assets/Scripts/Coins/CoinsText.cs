using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class CoinsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsTMP;
    
    private void OnEnable()
    {
        Actions.OnCoinCollected += ChangeCoinText;
        Actions.OnSkinBought += delegate(Skin skin) { ChangeCoinText(); };
        Actions.OnGameStarted += ChangeCoinText;
    }

    private void OnDisable()
    {
        Actions.OnCoinCollected -= ChangeCoinText;
        Actions.OnGameStarted -= ChangeCoinText;
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => YandexGame.SDKEnabled);
        _coinsTMP.text = $"Монеты: {YandexGame.savesData.Coins}";
    }

    private void ChangeCoinText()
    {
        _coinsTMP.text = $"Монеты: {CoinsCounter.Instance.Coins}";
    }
}