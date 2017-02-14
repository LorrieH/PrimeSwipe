using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    private int _Shape;

    private GameObject _Shape1;
    private GameObject _Shape2;
    private GameObject _Shape3;

    private List<GameObject> _Shapes;

    private bool _AllreadyFilled = false;

    // Use this for initialization
    void Start () {
        _Shape1 = Resources.Load<GameObject>("Shape1");
        _Shape2 = Resources.Load<GameObject>("Shape2");
        _Shape3 = Resources.Load<GameObject>("Shape3");

        _Shapes = new List<GameObject>();

        _Shapes.Add(_Shape1);
        _Shapes.Add(_Shape2);
        _Shapes.Add(_Shape3);

    }
	
	// Update is called once per frame
	void Update () {
        if (_AllreadyFilled == false)
        {
            SpawnNew();
            _AllreadyFilled = true;
        }
	}

    private void SpawnNew()
    {
        _Shape = Random.Range(0, 3);
        Instantiate(_Shapes[_Shape], this.transform.position, _Shapes[_Shape].transform.rotation);
    }
}
