using System.Collections; //cash me ousside howbow dah
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwipeManager : MonoBehaviour {

    public List<GameObject> GridCells = new List<GameObject>();
    private GameObject _comboStart;
    private List<GameObject> _comboObjects = new List<GameObject>();
    private List<GameObject> _comboWithoutDupes;
    public static int Turns = 20;
    private int _bonusCombo;

    void Start()
    {
        Turns = 20;
    }

    private void Raycast()
    {
        if (Turns > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (GridCells.Count != 0)
                {
                    if (GridCells[GridCells.Count - 1].gameObject != hit.transform.gameObject)
                    {
                        int number = 0;
                        for (int i = 0; i < GridCells.Count; i++)
                        {
                            if (number < 1)
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
                }
                else if (GridCells.Count == 0)
                {
                    GridCells.Add(hit.transform.gameObject);
                }
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
            if(Turns > 0)
            {
                if (GridCells.Count <= 2)
                {
                    GridCells.Clear();
                }
                else
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
    }

    private OndestroyShape _onDestroy;

    private void ComboCheck()
    {
        StartCoroutine(WaitForDestroy());
        Turns--;
    }

    private void ClearCombo()
    {
        _comboObjects.Clear();
        GridCells.Clear();
        _comboStart = null;
        _bonusCombo = 0;
    }

    IEnumerator WaitForDestroy() {
       _comboWithoutDupes = new HashSet<GameObject>(_comboObjects).ToList();

        if (_comboWithoutDupes.Count >= 3)
        {
            for (int i = 0; i < _comboWithoutDupes.Count; i++)
            {
                _onDestroy = _comboWithoutDupes[i].gameObject.GetComponent<OndestroyShape>();

                _onDestroy.OnDestroyShape();

                Score.score = Score.score + (100 * _comboWithoutDupes.Count);
                _bonusCombo++;
            }
            if(_bonusCombo >= 13)
            {
                Turns++;
                if(_bonusCombo >= 20)
                {
                    Score.score += 20000;
                }
            }
            yield return new WaitForSeconds(0.1f);

            for (int i = 0; i < _comboWithoutDupes.Count; i++)
            {
                Destroy(_comboWithoutDupes[i].gameObject);
            }
            ClearCombo();
        }
    }
}
