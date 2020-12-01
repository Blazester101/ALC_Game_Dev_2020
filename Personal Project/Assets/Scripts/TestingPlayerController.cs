using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPlayerController : MonoBehaviour
{
    private float maxSpeed = 10.0f;
    private float speed = 5.0f;
    private float bounds = 20;
    
    public float currentSpeed;
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    currentSpeed = playerRb.velocity.magnitude;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Moves the player forward and back based on verticalInput
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        // Moves the player left and right based on horizontalInput
        playerRb.AddForce(Vector3.right * speed * horizontalInput);

        if(transform.position.x < -bounds)
        {
            transform.position = new Vector3(-bounds,transform.position.y,transform.position.z);
        }
        if(transform.position.x > bounds)
        {
            transform.position = new Vector3(bounds,transform.position.y,transform.position.z);
        }
        if(transform.position.z < -bounds)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,-bounds);
        }
        if(transform.position.z > bounds)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,bounds);
        }
    }
}