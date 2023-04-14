using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRunAway : IAction
{
    [SerializeField]
    private GameObject target;
    private float timer;
  
    [SerializeField]
    private GameObject endpoint;


    [SerializeField]
    private GameObject runner;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float slowDownDistance;

    private Vector3 targetPosition;
    private Vector3 velocity;
    [SerializeField]
    private S_ModePlayer moveScript;
    public override void Act()
    {
        if(moveScript != null)
        {
            moveScript.enabled = true;
        }

        AvoidTarget(target);
    }
    private void AvoidTarget(GameObject target)
    {
       

        if (target != null)
        {


            timer += Time.deltaTime * speed;
            targetPosition = target.transform.position;

            if (runner.transform.position != targetPosition)
            {
                Vector3 distance = (targetPosition - runner.transform.position);

                Vector3 desiredVelocity = (distance.normalized * speed);
                Vector3 steering = desiredVelocity - velocity;

                velocity += steering * Time.deltaTime;

                float slowdownFactor = Mathf.Clamp01(distance.magnitude / slowDownDistance);
                velocity *= slowdownFactor;
                velocity.y = 0;//i don't know why it adds to the y axis

                endpoint.transform.position -= velocity * Time.deltaTime;

            }
        }
    }
}
