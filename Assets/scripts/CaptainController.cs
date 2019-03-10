using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
    	//Vector3 
    	float dt = Time.deltaTime;
    	//transform.Translate(1 * dt, 1 * dt, 1 * dt);

    	transform.position = transform.position + Camera.main.transform.forward * 1 * Time.deltaTime;

    	 //Vector2 joyState = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick); 
  
    }
}
