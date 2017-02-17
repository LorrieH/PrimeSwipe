using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    private AudioSource _source;

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!MuteButton.muted)
        {
            _source.volume = 1;
        }
        else
            _source.volume = 0;
    }
}
