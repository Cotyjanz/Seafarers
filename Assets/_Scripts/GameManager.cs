using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int combo;
	public static float score;
	public static float multiplier = 0.23f;

	public Text scoreText; 


	// Use this for initialization
	void Start () {
		combo = 0;
		score = 0;	
	}
	
	// Update is called once per frame
	void Update () {
		score = combo * 104 * multiplier;
		scoreText.text = ((int)score).ToString() + " POINTS!"; 

		if (score < 0) {
			//stop audio 
			//stop spawning
		}

	}
}
