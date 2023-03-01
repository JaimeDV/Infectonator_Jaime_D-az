using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RandomMove : MonoBehaviour
{
    private Grid grid;
    [SerializeField]
    private GameObject endpoint;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float minTimer;
    [SerializeField]
    private float maxTimer;
    private bool calm;
    void Start()
    {
        grid = GetComponent<Grid>();
        calm = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (calm)
        {
            timer-= 1 * Time.deltaTime;
            if(timer < 0)
            {
                changePath();
                float random = Random.Range(minTimer, maxTimer);
                timer += random;
            }

        }
    }
    private Node setPaths()
    {
            foreach(Node node in grid.nodeArray)
            {
                float random = Random.Range(0, 10000);
                if (random<5 && node.isNotWall)
                {
                    return node;
                }
            }
        return null;
    }
    private void changePath()
    {
        var newEnd=setPaths();

        if (newEnd != null)
        {
            endpoint.transform.position=newEnd.position;
        }
        else
        {
            changePath();
        }
    }
    private void panic()
    {
        calm = false;
    }
}
