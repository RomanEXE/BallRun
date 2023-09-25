using UnityEngine;

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
    [SerializeField] private GameObject _endGameUI;
    
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
        Actions.OnGameStarted.Invoke();
        _mainMenuUI.SetActive(false);
    }

    private void EndGame()
    {
        _endGameUI.SetActive(true);
    }
}