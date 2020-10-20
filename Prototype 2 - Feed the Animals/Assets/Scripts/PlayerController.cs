using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed the player moves at
    private float speed = 20.0f;
    // Variable for boundries
    private float bounds = 24.0f;
    // Sets up variable for movement
    private float horizontalInput;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        // Collect input data
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

        // Shoots projectile on space
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab,transform.position,projectilePrefab.transform.rotation);
        }
    }
}