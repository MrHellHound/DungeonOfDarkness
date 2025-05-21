using TMPro;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private GameObject keyWindow;
    private KeyCounter _keyCounter;

    private void Awake()
    {
        _keyCounter = GameObject.FindWithTag("Player").GetComponent<KeyCounter>();
        keyWindow.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            keyWindow.SetActive(true);
            _keyCounter.keyCount += 1;
            keyText.text = _keyCounter.keyCount.ToString();
            
            Destroy(gameObject);
        }
    }
}
