using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class EndGameUI : MonoBehaviour
{
    [SerializeField] private Button _closeBtn;
    [SerializeField] private TextMeshProUGUI _coinsCountTMP;
    
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += GiveAward;
        _closeBtn.onClick.AddListener(EndGame);
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= GiveAward;
        _closeBtn.onClick.RemoveAllListeners();
    }

    private void Start()
    {
        _coinsCountTMP.text = CoinsCounter.Instance.Coins.ToString();
    }

    private void GiveAward(int a)
    {
        CoinsCounter.Instance.Coins *= 2;
        EndGame();
    }

    private void EndGame()
    {
        YandexGame.savesData.Coins += CoinsCounter.Instance.Coins;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}