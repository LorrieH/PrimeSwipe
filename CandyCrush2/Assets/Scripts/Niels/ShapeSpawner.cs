using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    private int _shape;

    private GameObject _shape1;
    private GameObject _shape2;
    private GameObject _shape3;

    private List<GameObject> _shapes;

    private bool _AllreadyFilled = false;

    private GameObject _shapeSpawned;

    // Use this for initialization
    void Start () {

        _shape1 = Resources.Load<GameObject>("Shape1");
        _shape2 = Resources.Load<GameObject>("Shape2");
        _shape3 = Resources.Load<GameObject>("Shape3");

        _shapes = new List<GameObject>();

        _shapes.Add(_shape1);
        _shapes.Add(_shape2);
        _shapes.Add(_shape3);

    }
	
	// Update is called once per frame
	void Update () {
        if (_AllreadyFilled == false)
        {
            SpawnNew();
            _AllreadyFilled = true;
        }
        if (transform.childCount == 0)
        {
            _AllreadyFilled = false;
        }
	}

    private void SpawnNew()
    {
        _shape = Random.Range(0, 3);

        _shapeSpawned = _shapes[_shape];

        Instantiate(_shapeSpawned, this.transform.position, _shapeSpawned.transform.rotation).transform.parent = gameObject.transform;
    }
}
