using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent thiefEntered;
    [SerializeField] private UnityEvent thiefRunAway;

    private void OnTriggerEnter(Collider other)
    {
        thiefEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        thiefRunAway?.Invoke();
    }
}