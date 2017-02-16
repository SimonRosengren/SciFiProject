using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;
    bool isGrounded;

    public float speed;
    public float jumpPower;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (Input.GetKeyDown (KeyCode.Space))
        {
            rb.AddExplosionForce(jumpPower, transform.position, 2, 20, ForceMode.Impulse);
        }

        transform.Translate(x, 0, z);
    }
}
