using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetField : MonoBehaviour {

    AudioSource _audio;

    public bool TileReset = false;

    void Start() {
        _audio = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (SwipeManager.Turns > 0)
        {
            if (!MuteButton.muted)
            {
                _audio.Stop();
                _audio.Play();
            }
            StartCoroutine(ResetTime());
        }

    }

    IEnumerator ResetTime() {
        TileReset = true;
        this.transform.localScale += new Vector3(-0.1F, -0.1F, 0);
        yield return new WaitForEndOfFrame();
        this.transform.localScale += new Vector3(0.1f, 0.1F, 0);
        TileReset = false;
        SwipeManager.Turns--;
    }
}
