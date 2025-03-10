using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool _isPause = false;

    [SerializeField] GameObject pauseWindow;
    [SerializeField] GameObject playerRotation;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPause)
        {
            _isPause = true;
            pauseWindow.SetActive(true);
            playerRotation.GetComponent<PlayerRotation>().enabled = false;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isPause)
        {
            _isPause = false;
            pauseWindow.SetActive(false);
            playerRotation.GetComponent<PlayerRotation>().enabled = true;
            Time.timeScale = 1f;
        }
    }

    public void OnRestartButtonClick()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
