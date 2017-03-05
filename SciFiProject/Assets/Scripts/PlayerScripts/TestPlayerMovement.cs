using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;

    bool isGrounded;
    bool grabing;

    public float speed;
    public float jumpPower;
    public float reach;

    public GameObject currentRoom; //reference to the room currently used by the player

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
            rb.AddForce(0, 200, 0);
        }
        if (Input.GetButtonDown("Grab"))
        {
            grabing = true;
            Grab();
        }
        transform.Translate(x, 0, z);
    }
    void FixedUpdate()
    {

    }
    public void Grab()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.right);
        Debug.DrawRay(transform.position, fwd);
        if (Physics.Raycast(new Ray(transform.position, fwd), out hit, 1000f))
            print("There is a " + hit.transform.tag + "in front of the object!");
        else
            Debug.Log("Nothing!");
    }
}
