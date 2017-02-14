using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetField : MonoBehaviour {

    public bool TileReset = false;

    void OnMouseDown()
    {
        StartCoroutine(ResetTime());
    }

    IEnumerator ResetTime() {
        TileReset = true;

        yield return new WaitForEndOfFrame();

        TileReset = false;
    }
}
