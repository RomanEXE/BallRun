using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class DailyChallangeLauncher : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => YandexGame.SDKEnabled);
        GetComponent<Button>().interactable = CheckAccess();
    }

    public void OpenDailyChallange()
    {
        YandexGame.savesData.DailyChallangeLastLaunch = DateTime.Now.Day;
        SceneManager.LoadScene(1);
    }
    
    private bool CheckAccess()
    {
        return DateTime.Now.Day != YandexGame.savesData.DailyChallangeLastLaunch;
    }
}