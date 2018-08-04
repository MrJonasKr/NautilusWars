using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NautilusScript : MonoBehaviour {

    public Rigidbody NautilusRigidbody;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotation();
	}

    private void FixedUpdate()
    {
        ForwardMomentum();
    }

    void Rotation()
    {
        float SubRotationSpeed = 30f;
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * Time.deltaTime * SubRotationSpeed);
    }

    void ForwardMomentum()
    {
        float ForwardForce = 0.1f;
        if (NautilusRigidbody.velocity.z <= 10)
        {
            NautilusRigidbody.AddForce(0, 0, ForwardForce * Input.GetAxis("Vertical") * -1, ForceMode.Impulse);
        }
        
    }
}
