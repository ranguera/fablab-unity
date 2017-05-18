using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour {

	public float rot;

	// Use this for initialization
	void Start () {
		// happens once at the start
	}

	public void SetRotation(float f)
	{
		rot = f;
	}
	
	// Update is called once per frame
	void Update () {
		// happens all the time
		transform.Rotate(Vector3.up,rot);
	}
		
}
