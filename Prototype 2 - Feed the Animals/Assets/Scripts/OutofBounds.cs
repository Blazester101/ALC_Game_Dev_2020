using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    // Variables for bounds
    public float topBounds = -15.0f;
    public float lowerBounds = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy
        if(transform.position.z < topBounds)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z > lowerBounds)
        {
            Destroy(gameObject);
        }
    }
}
