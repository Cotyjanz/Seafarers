using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainController : MonoBehaviour
{

	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public bool canJump = true;
	public float jumpHeight = 2.0f;
	private bool grounded = true;
 
 
 
	void Awake () {
	    GetComponent<Rigidbody>().freezeRotation = true;
	    GetComponent<Rigidbody>().useGravity = false;
	}
 
	void FixedUpdate () {
		if (OVRInput.Get(OVRInput.Button.One)) {
			if (grounded) {
		        // Calculate how fast we should be moving
		        Vector3 targetVelocity =  Camera.main.transform.forward;
		        //local to global
		        targetVelocity = transform.TransformDirection(targetVelocity);
		        targetVelocity *= speed;
	 
		        // Apply a force that attempts to reach our target velocity
		        Vector3 velocity = GetComponent<Rigidbody>().velocity;
		        Vector3 velocityChange = (targetVelocity - velocity);
		        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
		        //No flying
		        velocityChange.y = 0;
		        GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

				// Jump
		        if (canJump && Input.GetButton("Jump")) {
		            GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
		        }
		    }

		}
	    // We apply gravity manually for more tuning control
	    GetComponent<Rigidbody>().AddForce(new Vector3 (0, -gravity * GetComponent<Rigidbody>().mass, 0));
 
	    grounded = false;
	}
 
	void OnCollisionStay () {
	    grounded = true;    
	}
 
	float CalculateJumpVerticalSpeed () {
	    // From the jump height and gravity we deduce the upwards speed 
	    // for the character to reach at the apex.
	    return Mathf.Sqrt(2 * jumpHeight * gravity);
	}

}

// My initial attempts at movement based on look direction were hidered by the fact that i needed to 
// use a rigid body due to the way my scene is setup.
//https://developer.oculus.com/reference/unity/1.35/class_o_v_r_input/
//https://developer.oculus.com/documentation/unity/latest/concepts/unity-ovrinput/

//http://wiki.unity3d.com/index.php?title=RigidbodyFPSWalker