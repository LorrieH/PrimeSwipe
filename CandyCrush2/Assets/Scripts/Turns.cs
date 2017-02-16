using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour {

    private Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = SwipeManager.Turns.ToString();
    }
}
