using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    None = 0,
    Left = 1,
    Right = 2,
    Up = 4,
    Down = 8,

    LeftDown = 9,
    LeftUp = 5,
    RightDown = 10,
    RightUp = 6
}

public class SwipeManager : MonoBehaviour {

    public SwipeDirection Direction { set; get; }

    private Vector3 _touchPosition;
    private float _swipeResistanceX = 30;
    private float _swipeResistanceY = 30;

    private void Update()
    {
        Direction = SwipeDirection.None;

        if (Input.GetMouseButtonDown(0))
        {
            _touchPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = _touchPosition - Input.mousePosition;

            if (Mathf.Abs(deltaSwipe.x) > _swipeResistanceX)
            {
                //swipe on x axis
                Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
            }
            if (Mathf.Abs(deltaSwipe.y) > _swipeResistanceY)
            {
                //swipe on y axis
                Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
            }
        }
    }

    public bool IsSwiping(SwipeDirection dir)
    {
        return (Direction & dir) == dir;
    }
}
