using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject cube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			GameObject go = (GameObject) Instantiate (cube, new Vector3 (0f, 4f, 0f), Quaternion.identity);
			Script1 s = go.GetComponent<Script1> ();
			s.SetRotation (Random.value * 100f);
		}
	}
}
