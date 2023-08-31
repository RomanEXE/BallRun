using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(Player.Instance.transform.position.x, -100, Player.Instance.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Actions.OnGameEnd.Invoke();
        }
    }
}