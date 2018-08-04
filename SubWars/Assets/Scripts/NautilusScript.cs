using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NautilusScript : MonoBehaviour {

    public Rigidbody NautilusRigidbody;
    public int NautilusSpeedLevel = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotation();
	}

    private void FixedUpdate()
    {
        NautilusSpeedLevelController();
        ForwardMomentum();
    }

    void Rotation()
    {
        float SubRotationSpeed = 30f;
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * Time.deltaTime * SubRotationSpeed);
    }

    void NautilusSpeedLevelController()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            NautilusSpeedLevel++;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            NautilusSpeedLevel--;
        }
        NautilusSpeedCapChecker();
        print(NautilusSpeedLevel);
    }

    void NautilusSpeedCapChecker()
    {
        if (NautilusSpeedLevel > 2)
        {
            NautilusSpeedLevel = 2;
        }
        else if (NautilusSpeedLevel < -1)
        {
            NautilusSpeedLevel = -1;
        }
    }

    //Sets the acceleration of 
    void ForwardMomentum()
    {
        float forwardForce = 0.75f;
        float calculatedForce = 0;
        switch (NautilusSpeedLevel)
        {
            case 2:
                calculatedForce = forwardForce * 1.2f;
                NautilusRigidbody.AddRelativeForce(0, calculatedForce, 0, ForceMode.Impulse);
                break;
            case 1:
                NautilusRigidbody.AddRelativeForce(0, forwardForce, 0, ForceMode.Impulse);
                break;
            case 0:
                NautilusRigidbody.velocity = new Vector3(0, 0, 0);
                NautilusRigidbody.drag = 0.00001f;
                break;
            case -1:
                calculatedForce = forwardForce * -1;
                NautilusRigidbody.AddRelativeForce(0, calculatedForce, 0, ForceMode.Impulse);
                break;
            default:
                break;
        }
    }
}
