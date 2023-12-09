using UnityEngine;

public class PlayerSolverIterations : MonoBehaviour
{
    [SerializeField] private int _iterations;

    private void Awake()
    {
        GetComponent<Rigidbody>().solverIterations = _iterations;
    }
}