using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HowToPlay : MonoBehaviour {

    [SerializeField]
    private int _sceneSelector;

    [SerializeField]
    private int _waitingTime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(StartGameOnTime());
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_sceneSelector);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    IEnumerator StartGameOnTime() {
        yield return new WaitForSeconds(_waitingTime);

        StartGame();
    }
}
