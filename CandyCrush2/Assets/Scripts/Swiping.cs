using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiping : MonoBehaviour {

    SwipeManager _swipeManager;

    void Start()
    {
        _swipeManager = GetComponent<SwipeManager>();
    }

	void Update () {
        if (_swipeManager.IsSwiping(SwipeDirection.Up)){
            //Debug.Log("Swipe Up");
        }
        if (_swipeManager.IsSwiping(SwipeDirection.Down))
        {
            //Debug.Log("Swipe Down");
        }
        if (_swipeManager.IsSwiping(SwipeDirection.Left))
        {
            //Debug.Log("Swipe Left");
        }
        if (_swipeManager.IsSwiping(SwipeDirection.Right))
        {
            //Debug.Log("Swipe Right");
        }
        if (_swipeManager.IsSwiping(SwipeDirection.LeftUp))
        {
            //Debug.Log("Swipe LeftUp");
        }
        if (_swipeManager.IsSwiping(SwipeDirection.RightUp))
        {
            //Debug.Log("Swipe RightUp");
        }
        if (_swipeManager.IsSwiping(SwipeDirection.LeftDown))
        {
            //Debug.Log("Swipe LeftDown");
        }
        if (_swipeManager.IsSwiping(SwipeDirection.RightDown))
        {
            //Debug.Log("Swipe RightDown");
        }
    }
}
