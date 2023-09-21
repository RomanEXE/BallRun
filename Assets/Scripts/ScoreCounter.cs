using System;
using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _score;
    [SerializeField] private float _scorePerSecond;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        Actions.OnGameEnd += OnGameEnd;
    }

    private void OnGameEnd()
    {
        var score = Convert.ToInt32(_score);
        
        if (score > YandexGame.savesData.RecordScore)
        {
            YandexGame.NewLeaderboardScores("Score", score);
            YandexGame.savesData.RecordScore = score;
        }
    }

    private IEnumerator Start()
    {
        _playerRigidbody = Player.Instance.GetComponent<Rigidbody>();

        yield return new WaitUntil(() => YandexGame.SDKEnabled);
        _scoreText.text = $"Текущий рекорд: {YandexGame.savesData.RecordScore}";
    }

    private void Update()
    {
        if (_playerRigidbody.velocity.z > 0)
        {
            _score += _playerRigidbody.velocity.z * _scorePerSecond * Time.deltaTime;
            _scoreText.text = $"Счёт: {(int)_score}";
        }
    }
}