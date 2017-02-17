using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    public static bool muted;
    private Image _image;
    [SerializeField]private Sprite[] _muteSprites;

    void Start()
    {
        _image =  GetComponent<Image>();
        SetImage();
    }

    public void Mute()
    {
        muted =  !muted;
        SetImage();
    }

    private void SetImage()
    {
        if (muted)
        {
            _image.sprite = _muteSprites[1];
        }
        else
            _image.sprite = _muteSprites[0];
    }
}
