using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float bounds = 20;
    
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Moves the player forward and back based on verticalInput
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // Moves the player left and right based on horizontalInput
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

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
