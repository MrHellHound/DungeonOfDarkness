using UnityEngine;
using UnityEngine.SceneManagement;

public class GameContinue : MonoBehaviour
{
    public void OnGameContinueButtonClick()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("OpenLevels"));
    }
}
