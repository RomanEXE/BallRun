using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Actions.OnCoinCollected.Invoke();
        Destroy(gameObject);
    }
}