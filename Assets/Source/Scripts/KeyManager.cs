using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private Transform nextDoorTransform;
    private KeyCounter _keyCounter;
    private Transform _playerTransform;

    private void Awake()
    {
        _keyCounter = GameObject.FindGameObjectWithTag("Player").GetComponent<KeyCounter>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && _keyCounter.keyCount == 1)
        {
            _playerTransform.position = nextDoorTransform.position;
        }
    }
}
