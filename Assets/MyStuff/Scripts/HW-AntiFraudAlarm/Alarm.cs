using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent thiefEntered;
    [SerializeField] private UnityEvent thiefRunAway;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        thiefEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        thiefRunAway?.Invoke();
    }
}