using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRandomMove : IAction
{
    /// <summary>
    /// action that moves the object in a A* grid, it activates the random move script in pathfinderholder
    /// </summary>
    /// 
    //[SerializeField]
    //private Grid grid;
    //private Node cuarrentNode;
    //private int nodePosition;

    //[SerializeField]
    //private GameObject player;


    //private float timer;
    //private Vector3 startPosition;
    //private List<Node> finalPath;

    //[SerializeField]
    //private float speed;


    //[SerializeField]
    //private float slowDownDistance;

    //private Vector3 cuarrentNodeDistance;
    //private Vector3 velocity;
    //private void Awake()
    //{
    //    finalPath = grid.FinalPath;
    //    CheckNode();
    //    velocity = Vector3.zero;
    //}
    //public override void Act()
    //{
    //    MoveToTarget();
    //}

    //private void MoveToTarget()
    //{
    //    if (finalPath != null && finalPath.Count > 0)//should change it so it continues moving
    //    {
    //        timer += Time.deltaTime * speed;

    //        if (player.transform.position != cuarrentNodeDistance)
    //        {
    //            Vector3 distance = (cuarrentNodeDistance - player.transform.position);

    //            Vector3 desiredVelocity = (distance.normalized * speed);
    //            Vector3 steering = desiredVelocity - velocity;

    //            velocity += steering * Time.deltaTime;

    //            float slowdownFactor = Mathf.Clamp01(distance.magnitude / slowDownDistance);
    //            velocity *= slowdownFactor;
    //            velocity.y = 0;//i don't know why it adds to the y axis
    //            player.transform.position += velocity * Time.deltaTime;
    //            //player.transform.position = Vector3.Lerp(startPosition, cuarrentNodeDistance, timer);
    //        }
    //        else
    //        {
    //            if (nodePosition < finalPath.Count - 1)
    //            {
    //                nodePosition++;
    //                CheckNode();
    //            }
    //        }
    //    }
    //}
    //private void CheckNode()
    //{
    //    if (finalPath != null && finalPath.Count > 0)
    //    {
    //        timer = 0;
    //        startPosition = player.transform.position;
    //        cuarrentNodeDistance = finalPath[nodePosition].position;
    //    }
    //}
    [SerializeField]
    private S_ModePlayer moveScript;

    public override void Act()
    {
        if(moveScript != null)
        {
            moveScript.enabled = true;
        }
    }
}
