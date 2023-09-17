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
    }

    private void OnDisable()
    {
        Actions.OnCoinCollected -= ChangeCoinText;
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => YandexGame.SDKEnabled);
        ChangeCoinText();
    }

    private void ChangeCoinText()
    {
        _coinsTMP.text = $"Монеты: {YandexGame.savesData.Coins.ToString()}";
    }
}