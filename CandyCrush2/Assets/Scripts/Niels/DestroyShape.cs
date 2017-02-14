using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShape : MonoBehaviour {

    private ResetField _reset;

    [SerializeField]
    private GameObject _resetButton;

    private bool _resetTile;

    // Use this for initialization
    void Start () {
        _resetButton = GameObject.Find("Reset");

        _reset = _resetButton.GetComponent<ResetField>();
    }
	
	// Update is called once per frame
	void Update () {
        _resetTile = _reset.TileReset;

        if (_resetTile == true)
        {
            Destroy(this.gameObject);
        }
    }
}
