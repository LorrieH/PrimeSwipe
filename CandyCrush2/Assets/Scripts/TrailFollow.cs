using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFollow : MonoBehaviour {

    [SerializeField]private GameObject _trail;

	void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _trail.transform.position = new Vector3(mousePos.x, mousePos.y, -1);
        }
	}
}
