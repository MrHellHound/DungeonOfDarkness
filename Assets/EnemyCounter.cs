using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI totalEnemies;
    [SerializeField] TextMeshProUGUI enemiesLeft;
    
    private GameObject[] _totalEnemies;
    private int _totalEnemiesLeft;
    
    [SerializeField] GameObject door;
    
    private void Awake()
    {
        _totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        _totalEnemiesLeft = _totalEnemies.Length;
        
        totalEnemies.text = _totalEnemiesLeft.ToString();
        enemiesLeft.text = _totalEnemiesLeft.ToString();
    }

    public void UpdateUI()
    {
        _totalEnemiesLeft--;
        enemiesLeft.text = _totalEnemiesLeft.ToString();
        
        if (_totalEnemiesLeft == 0 && door != null)
        {
            door.SetActive(false);
        }
    }
    
}
