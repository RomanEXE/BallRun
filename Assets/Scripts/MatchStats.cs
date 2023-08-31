using System;
using UnityEngine;

public class MatchStats : MonoBehaviour
{
    public Action OnPlayerLose;
    public int CollectedCoins;
    public float Score;
    public int ScoreMultiplyBonus;

    private void OnEnable()
    {
        Actions.OnCoinCollected += delegate()
        {
            CollectedCoins++;
        };
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameStarted)
        {
            Score = Player.Instance.transform.position.z;
        }
    }
}