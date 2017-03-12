using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraBehaviour : MonoBehaviour {

    public GameObject player; //reference to player

    private TestPlayerMovement playerScript;
    private GameObject currentRoom;

    private Vector3 speed;
    private float minDistance;
    

	// Use this for initialization
	void Start ()
    {
        playerScript = (TestPlayerMovement)player.GetComponent(typeof(TestPlayerMovement));
        minDistance = 0.006f;
	}   
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
	}

    // Called at the end of frame
    private void LateUpdate()
    {
        currentRoom = playerScript.currentRoom;
        if (currentRoom.GetComponent<MeshRenderer>().Equals(null)) //To check so that the room actually have a mesh renderer
        {
            return;
        }
        Vector3 roomCenter = currentRoom.GetComponent<MeshRenderer>().bounds.center;
        float roomWidth = currentRoom.GetComponent<MeshRenderer>().bounds.size.x;
        if (transform.position.x != roomCenter.x || transform.position.y != roomCenter.y)
            MoveToPosition(new Vector3(roomCenter.x, roomCenter.y, transform.position.z));
    }

    // Moves the camera to a new position
    private void MoveToPosition(Vector3 newPosition)
    {
        speed = (newPosition - transform.position) / 50;

        float x = speed.x * Time.deltaTime;
        float y = speed.y * Time.deltaTime;
        float z = speed.z * Time.deltaTime;
        if (Vector3.Distance(transform.position, newPosition) < minDistance)
            transform.position = newPosition;
        transform.Translate(speed);
    }
}
