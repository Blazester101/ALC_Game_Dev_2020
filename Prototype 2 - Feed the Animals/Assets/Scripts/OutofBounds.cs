using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    // Variables for bounds
    private float topBounds = -15.0f;
    private float lowerBounds = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy when out of bounds
        if(transform.position.z < topBounds)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z > lowerBounds)
        {
            Destroy(gameObject);
            // Game Over!
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }
}
