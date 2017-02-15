using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndestroyShape : MonoBehaviour {

    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private int _waitTime;

    void Awake() {
        _anim = GetComponent<Animator>();
    }

    void OnDestroy() {
        _anim.SetTrigger("death");
        //StartCoroutine(Wait());
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(_waitTime);
    }
}
