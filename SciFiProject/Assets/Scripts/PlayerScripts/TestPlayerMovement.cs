using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;

    public float speed;

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

        transform.Translate(x, 0, z);
    }
}
