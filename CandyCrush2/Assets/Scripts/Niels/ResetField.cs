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
        this.transform.localScale += new Vector3(-0.1F, -0.1F, 0);
        yield return new WaitForEndOfFrame();
        this.transform.localScale += new Vector3(0.1f, 0.1F, 0);
        TileReset = false;
    }
}
