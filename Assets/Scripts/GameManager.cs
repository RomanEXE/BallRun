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
    
    [SerializeField] private GameObject _mainMenuUI;
    
    private void OnEnable()
    {
        Actions.OnGameEnd += EndGame;
    }

    private void OnDisable()
    {
        Actions.OnGameEnd -= EndGame;
    }

    public void StartGame()
    {
        _mainMenuUI.SetActive(false);
    }

    private void EndGame()
    {
        YandexGame.SaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}