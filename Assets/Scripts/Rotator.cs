using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(new Vector3(10,4,3)*Time.deltaTime);
	}
}
