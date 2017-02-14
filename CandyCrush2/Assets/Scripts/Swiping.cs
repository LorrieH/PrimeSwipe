using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiping : MonoBehaviour {

    SwipeManager swipeManager;

    void Start()
    {
        swipeManager = GetComponent<SwipeManager>();
    }

	void Update () {
        if (swipeManager.IsSwiping(SwipeDirection.Up)){
            Debug.Log("Swipe Up");
        }
        if (swipeManager.IsSwiping(SwipeDirection.Down))
        {
            Debug.Log("Swipe Down");
        }
        if (swipeManager.IsSwiping(SwipeDirection.Left))
        {
            Debug.Log("Swipe Left");
        }
        if (swipeManager.IsSwiping(SwipeDirection.Right))
        {
            Debug.Log("Swipe Right");
        }
        if (swipeManager.IsSwiping(SwipeDirection.LeftUp))
        {
            Debug.Log("Swipe LeftUp");
        }
        if (swipeManager.IsSwiping(SwipeDirection.RightUp))
        {
            Debug.Log("Swipe RightUp");
        }
        if (swipeManager.IsSwiping(SwipeDirection.LeftDown))
        {
            Debug.Log("Swipe LeftDown");
        }
        if (swipeManager.IsSwiping(SwipeDirection.RightDown))
        {
            Debug.Log("Swipe RightDown");
        }
    }
}
