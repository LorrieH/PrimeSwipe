using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text _text;
    [SerializeField]private string _string;

    public static int score;

    void Awake()
    {
        _text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        _text.text = _string + score.ToString();
    }
}