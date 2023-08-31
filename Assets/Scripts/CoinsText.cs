using System;
using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsTMP;
    [SerializeField] private MatchStats _matchStats;
    
    private void OnEnable()
    {
        Actions.OnCoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        Actions.OnCoinCollected -= OnCoinCollected;
    }

    private void Start()
    {
        _matchStats = Player.Instance.GetComponent<MatchStats>();
    }

    private void OnCoinCollected()
    {
        _coinsTMP.text = $"Монеты: {_matchStats.CollectedCoins.ToString()}";
    }
}
