using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    Rigidbody rigidBody;
	public float forceMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		if ((Mathf.Abs(x)>0)||(Mathf.Abs(z)>0))
			rigidBody.AddForce(new Vector3(x * forceMultiplier, 0, z * forceMultiplier)); 
    }
}
