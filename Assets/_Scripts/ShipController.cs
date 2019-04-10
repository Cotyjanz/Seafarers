using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

	private float prevRot = 0.0f;
	private float rot = 0.0f;
	private bool moveboat = false;

    // Start is called before the first frame update
    void Start()
    {

    }

 	private void OnCollisionExit (Collision hit)
 	{
 		GameObject.Find("captain").transform.parent = null;
 		moveboat = false;
 	}

 	private void OnCollisionStay (Collision hit) 
	{ 
    	if(hit.gameObject.name == ("captain")) {
        	GameObject.Find("captain").transform.parent = GameObject.Find("PlayerVessel").transform; 
    	}else{
        	GameObject.Find("captain").transform.parent = null;
 		}

 		moveboat = true;
 	}

    // Update is called once per frame
    void FixedUpdate()
    {
    	GameObject wheel = GameObject.Find("BoatWheel");

		//print(wheel.transform.localEulterAngles.x);
    	//rot = wheel.transform.localEulerAngles.x - prevRot;
    	//print(rot);

		//transform.position = transform.position + -transform.right * 1 * Time.deltaTime;
		//GetComponent<Rigidbody>().AddRelativeTorque(transform.up * rot * 0.00001f, ForceMode.Impulse);
		
    	if (moveboat)
    	{
    	//GetComponent<Rigidbody>().AddForce(-transform.right * 20, ForceMode.Impulse);
		//print(GetComponent<Rigidbody>().velocity);
		//GetComponent<Rigidbody>().AddRelativeTorque(0.0f, rot * 0.0006f, 0.0f);
    	}

    	prevRot = rot; 
    }
}
