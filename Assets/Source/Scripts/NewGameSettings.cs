using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameSettings : MonoBehaviour
{
    public void OnNoTutorialButtonClick()
    {
        PlayerPrefs.DeleteKey("OpenLevels");
        PlayerPrefs.SetInt("OpenLevels", 2);
        SceneManager.LoadScene(2);
    }

    public void OnTutorialButtonClick()
    {
        PlayerPrefs.DeleteKey("OpenLevels");
        PlayerPrefs.SetInt("OpenLevels", 1);
        SceneManager.LoadScene(1);
    }
}
