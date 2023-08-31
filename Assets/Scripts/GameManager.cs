using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            
            return _instance;
        }
    }
    
    [SerializeField] private bool _isGameStarted;
    public bool IsGameStarted => _isGameStarted;
    [SerializeField] private GameObject _mainMenuUI;
    
    private void OnEnable()
    {
        Actions.OnGameStarted += StartGame;
        Actions.OnGameEnd += EndGame;
    }

    private void OnDisable()
    {
        Actions.OnGameStarted -= StartGame;
        Actions.OnGameEnd -= EndGame;
    }

    public void StartGame()
    {
        _isGameStarted = true;
        _mainMenuUI.SetActive(false);
        print(YandexGame.savesData.Coins.ToString());

    }

    private void EndGame()
    {
        //_isGameStarted = false;
        //_mainMenuUI.SetActive(true);

        YandexGame.SaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnApplicationQuit()
    {
        YandexGame.SaveProgress();
    }
}