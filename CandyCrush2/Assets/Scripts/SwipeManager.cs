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
    private float _swipeResistanceX = 20;
    private float _swipeResistanceY = 20;
    public GameObject obj;
    public List<GameObject> GridCells = new List<GameObject>();

    private void InstantiateObj(int index)
    {
        Instantiate(obj, new Vector3(GridCells[index].transform.position.x, GridCells[index].transform.position.y, 0), Quaternion.identity);
    }

    private void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (GridCells.Count != 0)
            {
                if (GridCells[GridCells.Count - 1].gameObject != hit.transform.gameObject)
                {
                    Debug.Log("object hit: " + hit.transform.gameObject);
                    GridCells.Add(hit.transform.gameObject);
                    Debug.Log("grid count" + GridCells.Count);
                }

            } else if (GridCells.Count == 0)
            {
                GridCells.Add(hit.transform.gameObject);
                Debug.Log("object hit: " + hit.transform.gameObject);
            }


            /*if(GridCells[0] == null)
            {
                GridCells.Add(hit.transform.gameObject);
                InstantiateObj(0);
                //Debug.Log(GridCells[0].gameObject);
            }
            else if(GridCells[1] == null)
            {
                GridCells.Add(hit.transform.gameObject);
                InstantiateObj(1);
                //Debug.Log(GridCells[1].gameObject);
            }
            else
            {
                for(int i = 0; i < GridCells.Count; i++)
                {
                    GridCells[i] = null;
                }
                GridCells[0] = hit.transform.gameObject;
                InstantiateObj(0);
                //Debug.Log(GridCells[0].gameObject);
            }*/
        }
    }

    private void Update()
    {
        Direction = SwipeDirection.None;

        if (Input.GetMouseButton(0))
        {
            Raycast();
        }
        if (Input.GetMouseButtonDown(0))
        {
            _touchPosition = Input.mousePosition;
            //Raycast();  
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

            //Raycast();
        }
    }

    public bool IsSwiping(SwipeDirection dir)
    {
        return (Direction & dir) == dir;
    }
}
