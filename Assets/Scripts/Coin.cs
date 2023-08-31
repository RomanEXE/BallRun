using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnEnable()
    {
        Actions.OnCoinCollected += delegate
        {
            //Destroy(gameObject);
        };
    }
}