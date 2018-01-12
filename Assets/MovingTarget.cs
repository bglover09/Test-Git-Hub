using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingTarget : MonoBehaviour {

    float speed = .8f;
    private float zMax = 4.5f;
    private float zMin = -4.5f;
    private int dir = 1;
	private float radius = 4;
	private float theta = 0;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		theta = theta + speed * Time.deltaTime;
		theta = theta % 360;
		var newX = Mathf.Cos(theta ) * radius;
		var newZ = Mathf.Sin (theta ) * radius;
        transform.position = new Vector3(newX, .75f, newZ);
		
	}
}
