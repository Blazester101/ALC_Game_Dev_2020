using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float bounds = 24.0f;
    private float horizontalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Collerct input data
        horizontalInput = Input.GetAxis("Horizontal");
        
        // Moves player left and right
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Adds bounds to the right and left
        if(transform.position.x < -bounds)
        {
            transform.position = new Vector3(-bounds,transform.position.y,transform.position.z);
        }
        if(transform.position.x > bounds)
        {
            transform.position = new Vector3(bounds,transform.position.y,transform.position.z);
        }
    }
}