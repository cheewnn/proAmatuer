using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterA : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        transform.Rotate(90 * Time.deltaTime, 200 * Time.deltaTime, 0);
    }
}
