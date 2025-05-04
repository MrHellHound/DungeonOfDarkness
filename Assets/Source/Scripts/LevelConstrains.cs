using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelConstrains : MonoBehaviour
{
    [SerializeField] private int currentNumberOfOpenLevels;

    [SerializeField] GameObject[] levelButtons;

    private void Awake()
    {
        currentNumberOfOpenLevels = PlayerPrefs.GetInt("OpenLevels", 1);
        Debug.Log(currentNumberOfOpenLevels);
    }

    private void Start()
    {
        for (int i = 0; i < currentNumberOfOpenLevels; i++)
        {
            levelButtons[i].GetComponent<Button>().interactable = true;
        }
    }
}
