using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {

    public void SwitchScene(int _int)
    {  
        SceneManager.LoadScene(_int);
    }
}
