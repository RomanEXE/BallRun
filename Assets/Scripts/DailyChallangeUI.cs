using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class DailyChallangeUI : MonoBehaviour
{
    [SerializeField] private DailyChallange _dailyChallange;
    
    [SerializeField] private TextMeshProUGUI _rewardForPinTMP;
    [SerializeField] private TextMeshProUGUI _droppedCountTMP;
    [SerializeField] private TextMeshProUGUI _rewardTMP;
    [SerializeField] private Button _videoRewardBtn;

    private void Start()
    {
        _rewardForPinTMP.text += _dailyChallange.RewardForPin;
        _droppedCountTMP.text += _dailyChallange.DroppedPinsCount;
        _rewardTMP.text += _dailyChallange.Reward;

        _videoRewardBtn.enabled = YandexGame.nowVideoAd;
    }
}