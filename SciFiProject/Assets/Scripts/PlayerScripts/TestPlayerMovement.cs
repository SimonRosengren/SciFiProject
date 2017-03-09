using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;

    bool isGrounded;
    float reach = 1;

    GameObject grabbedItem;

    public float speed;
    public float jumpPower;


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

        

        if (Input.GetKeyDown (KeyCode.Space) && isGrounded)
        {
            rb.AddForce(0, 200, 0);
            isGrounded = false;
        }
        if (Input.GetButtonUp("Grab"))
        {
            grabbedItem = null; //Reset the grabbed item
        }
        if (Input.GetButton("Grab"))
        {
            Grab();
        }
        transform.Translate(0, 0, x);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {

    }
    public void Grab()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(new Ray(transform.position, fwd), out hit, reach))
        {
            if (hit.transform.tag == "Grabable")
            {
                grabbedItem = hit.transform.gameObject;
                grabbedItem.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }

        if (grabbedItem != null)
        {
            grabbedItem.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
        }
    }
}
