using System.Collections; //cash me ousside howbow dah
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public GameObject obj;
    public List<GameObject> GridCells = new List<GameObject>();
    private GameObject _comboStart;
    private List<GameObject> _comboObjects = new List<GameObject>();
    private List<GameObject> _comboWithoutDupes;

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
                if (GridCells[GridCells.Count -1].gameObject != hit.transform.gameObject)
                {
                    int number = 0;
                    for (int i = 0; i < GridCells.Count; i++)
                    {
                        if(number < 1)
                        {
                            if (GridCells[i].gameObject == hit.transform.gameObject)
                            {
                                break;
                            }
                            else
                            {
                                GridCells.Add(hit.transform.gameObject);
                                number++;
                            }
                        }
                    }
                }

            } else if (GridCells.Count == 0)
            {
                GridCells.Add(hit.transform.gameObject);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Raycast();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (GridCells.Count <= 2)
            {
                GridCells.Clear();
            } else
            {
                    for (int i = 0; i < GridCells.Count; i++)
                    {
                        if (_comboStart != null)
                        {
                            if (_comboObjects.Count >= 1)
                            {
                                if (GridCells[i].gameObject.transform.GetChild(0).gameObject.tag != _comboStart.tag)
                                {
                                    Debug.Log("Awh, you did not make a combo");
                                    ClearCombo();
                                    break;
                                }
                                else
                                {
                                    Debug.Log("Good job, you made a combo ( ͡° ͜ʖ ͡°)");
                                    _comboObjects.Add(GridCells[i].gameObject.transform.GetChild(0).gameObject);
                                }
                            }
                        }
                        else
                        {
                            _comboStart = GridCells[i].gameObject.transform.GetChild(0).gameObject;
                            if (_comboObjects.Count == 0)
                            {
                                _comboObjects.Add(_comboStart);
                            }
                        }
                    }
                _comboStart = null;
                ComboCheck();
            }
           
        }
    }

    private OndestroyShape _onDestroy;

    private void ComboCheck()
    {
        StartCoroutine(WaitForDestroy());
    }

    private void ClearCombo()
    {
        _comboObjects.Clear();
        GridCells.Clear();
        _comboStart = null;
    }

    IEnumerator WaitForDestroy() {
       _comboWithoutDupes = new HashSet<GameObject>(_comboObjects).ToList();

        if (_comboWithoutDupes.Count >= 3)
        {
            for (int i = 0; i < _comboWithoutDupes.Count; i++)
            {
                _onDestroy = _comboWithoutDupes[i].gameObject.GetComponent<OndestroyShape>();

                _onDestroy.OnDestroyShape();
            }
            yield return new WaitForSeconds(1);

            for (int i = 0; i < _comboWithoutDupes.Count; i++)
            {
                Destroy(_comboWithoutDupes[i].gameObject);
                Score.score = Score.score + (100 * _comboWithoutDupes.Count);
            }
            ClearCombo();
        }
    }
}
