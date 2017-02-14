using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetField : MonoBehaviour {

    public bool TileReset = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(TileReset); 
	}

    void OnMouseDown()
    {
        TileReset = true;

        TileReset = false;
    }
}
