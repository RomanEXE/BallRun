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
    [SerializeField] private FixedJoystick _joystick;
    
    private void OnEnable()
    {
        Actions.OnPinDrop += AddDroppedPin;
        Actions.OnGameEnd += ShowResults;
        YandexGame.RewardVideoEvent += EndChallenge;
    }

    private void OnDisable()
    {
        Actions.OnPinDrop -= AddDroppedPin;
        Actions.OnGameEnd -= ShowResults;
        YandexGame.RewardVideoEvent -= EndChallenge;
    }
    
    private void AddDroppedPin()
    {
        _droppedPinsCount++;
    }
    
    private void ShowResults()
    {
        _reward = _droppedPinsCount * _rewardForPin;
        _joystick.gameObject.SetActive(false);
        _resultsUI.SetActive(true);
    }

    public void EndChallenge(int id)
    {
        YandexGame.savesData.Coins += _reward;
        YandexGame.SaveProgress();
        SceneManager.LoadScene(0);
    }
}