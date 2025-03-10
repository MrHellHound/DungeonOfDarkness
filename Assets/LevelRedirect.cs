using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRedirect : MonoBehaviour
{
    public void OnRedirectButtonClick(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }
}
