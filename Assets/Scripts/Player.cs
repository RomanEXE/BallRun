using UnityEngine;
using YG;

public class Player : MonoBehaviour
{
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Player>();
            
            return _instance;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var interactable = other.GetComponent<IInteractable>();

        if (interactable != null)
        {
            interactable.Interact();
        }
        
        if (other.transform.CompareTag("Coin"))
        {
            YandexGame.savesData.Coins++;
            Actions.OnCoinCollected.Invoke();
            Destroy(other.gameObject);
        }
    }
}