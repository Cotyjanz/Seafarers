using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject[] beets;
	public Transform[] points;
	public float beat = (60 / 130) * 2;
	private float timer;

	void Start () {
		
	}
	
	void Update () {

		if (timer > beat) {
			GameObject beet = Instantiate(beets[Random.Range(0, 2)], points[Random.Range(0, 4)]);
			beet.transform.localPosition = Vector3.zero;
			beet.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
			timer -= beat;
		}

		timer += Time.deltaTime;
		
	}
}
