using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {

    [SerializeField]
    private int _sceneSelector;
    [SerializeField]
    private int _sceneSelector2;

    public void StartGame()
    {
        SceneManager.LoadScene(_sceneSelector);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(_sceneSelector2);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(_sceneSelector);
    }
}
