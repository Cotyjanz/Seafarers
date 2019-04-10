﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beets : MonoBehaviour {

	private Rigidbody rb;

	private float timer = 0;

	private bool hasEntered;
	private bool hasExited;
	private bool axeHeadHit;

	void start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
			timer += Time.deltaTime;

			if (timer > 7f) {
				GameManager.score -= 373; //GameManager is now GameManager
				Object.Destroy(this.gameObject);
				return;
			}
		
			if (hasEntered && hasExited && axeHeadHit) {
				GameManager.combo += 1;
				Debug.Log(GameManager.combo);
				Object.Destroy(this.gameObject);
				return; 
			} 

			if (hasEntered && hasExited) {
				rb.isKinematic = false;
        		rb.detectCollisions = true;
        		GameManager.combo += 1;
			}

			//forward states a direction of +Z, forward * -1 for -Z
			transform.position += Time.deltaTime * (transform.forward * -1) * 2;
	}

	private void OnTriggerEnter(Collider other) {
			if (other.tag == "AxeHead") {
				hasEntered = true;
				axeHeadHit = true;
			}
			if (other.tag == "AxeHandle") {
				hasEntered = true;

			}
			//Object.Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other) {

    		hasExited = true;

    }

}