using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class DailyChallange : MonoBehaviour
{
    [SerializeField] private int _droppedPinsCount;
    public int DroppedPinsCount => _droppedPinsCount;
    [SerializeField] private int _rewardForPin;
    public int RewardForPin => _rewardForPin;
    [SerializeField] private int _reward;
    public int Reward => _reward;
    [SerializeField] private GameObject _resultsUI;
    
    private void OnEnable()
    {
        Actions.OnPinDrop += AddDroppedPin;
        Actions.OnGameEnd += ShowResults;
        YandexGame.RewardVideoEvent += GetVideoReward;
    }

    private void OnDisable()
    {
        Actions.OnPinDrop -= AddDroppedPin;
        Actions.OnGameEnd -= ShowResults;
        YandexGame.RewardVideoEvent -= GetVideoReward;
    }
    
    private void AddDroppedPin()
    {
        _droppedPinsCount++;
    }
    
    private void ShowResults()
    {
        _reward = _droppedPinsCount * _rewardForPin;
        _resultsUI.SetActive(true);
    }

    public void EndChallenge()
    {
        YandexGame.savesData.Coins += _reward;
        SceneManager.LoadScene(0);
    }

    private void GetVideoReward(int a)
    {
        _reward *= 2;
        EndChallenge();
    }
}