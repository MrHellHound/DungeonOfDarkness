using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    private int _openLevels;
    
    private void Awake()
    {
        _openLevels = PlayerPrefs.GetInt("OpenLevels");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            if (_openLevels <= sceneIndex & _openLevels < SceneManager.sceneCountInBuildSettings-1)
            {
                PlayerPrefs.SetInt("OpenLevels", _openLevels+1);
            }

            if (SceneManager.sceneCountInBuildSettings > sceneIndex+1)
            {
                SceneManager.LoadScene(sceneIndex+1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
