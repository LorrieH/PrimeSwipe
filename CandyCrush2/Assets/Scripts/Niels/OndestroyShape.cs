using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndestroyShape : MonoBehaviour {
    AudioSource _audio;

    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private int _waitTime;

    void Awake() {
        _anim = GetComponent<Animator>();

        _audio = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    public void OnDestroyShape() {
        if (!MuteButton.muted)
        {
            _audio.Stop();
            _audio.Play();
        }
        _anim.SetTrigger("death");
        //StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(_waitTime);
    }
}
