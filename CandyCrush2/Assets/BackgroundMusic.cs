using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    private AudioSource _source;
    private static BackgroundMusic _instance;

    void Awake()
    {
        _source = GetComponent<AudioSource>();
        if (!_instance)
        {
            _instance = this;
        }
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
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
