using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    private Vector3 _touchPosition;
    private float _swipeResistanceX = 50f;
    private float _swipeResistanceY = 100f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _touchPosition = Input.mousePosition;
        }
    }
}
