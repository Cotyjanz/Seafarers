using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enum_devices : MonoBehaviour {

	// Use this for initialization
	void Start () {

		for (int i = 0; i < (Input.GetJoystickNames()).Length; i++) {
			Debug.Log(Input.GetJoystickNames()[i]);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
