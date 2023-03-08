using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_hardcodedEndpointLimit : MonoBehaviour
{
    /// <summary>
    /// a hardcoded solution to keep que pathfinding endpoint inside the grid
    /// </summary>
    [SerializeField]
    private Vector2 horizontalLimit;
    [SerializeField]
    private Vector2 verticalLimit;
    [SerializeField]
    private GameObject endpoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endpoint.transform.position.x > horizontalLimit.x)//x positive y negative
        {
            endpoint.transform.position= new Vector3(horizontalLimit.x, endpoint.transform.position.y, endpoint.transform.position.z);
        }
        if (endpoint.transform.position.x < horizontalLimit.y)
        {
            endpoint.transform.position = new Vector3(horizontalLimit.y, endpoint.transform.position.y, endpoint.transform.position.z);
        }
        if (endpoint.transform.position.z > verticalLimit.x)//x positive y negative
        {
            endpoint.transform.position = new Vector3(endpoint.transform.position.y, endpoint.transform.position.y, verticalLimit.x);
        }
        if (endpoint.transform.position.z < verticalLimit.y)//x positive y negative
        {
            endpoint.transform.position = new Vector3(endpoint.transform.position.y, endpoint.transform.position.y, verticalLimit.y);
        }
    }
}
