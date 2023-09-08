using UnityEngine;

public class ForceBooster : MonoBehaviour, IInteractable
{
    [SerializeField] private Vector3 _force;
    
    public void Interact()
    {
        Player.Instance.GetComponent<Rigidbody>().AddForce(_force, ForceMode.Force);
    }
}