using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeObject : MonoBehaviour {

    private Animator _anim;
    private Button _button;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
        if(GetComponent<Button>() != null)
        {
            _button = GetComponent<Button>();
            _button.interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (SwipeManager.Turns < 1)
        {
            _anim.SetBool("GameOver", true);
            if(_button != null)
            {
                _button.interactable = true;
            }
        }
    }
}
