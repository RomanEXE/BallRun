using UnityEngine;
using YG;

public class Coin : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        YandexGame.savesData.Coins++;
        Actions.OnCoinCollected.Invoke();
        Destroy(gameObject);
    }
}