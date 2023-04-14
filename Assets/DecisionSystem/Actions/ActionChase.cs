using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ActionChase : IAction
{
    /// <summary>
    /// chase an target, unlike the wander funtion it doesn't use A* due to time constrains
    /// </summary>
  

    //[SerializeField]
    //private GameObject test;

    [SerializeField]
    private Grid grid;

    [SerializeField]
    private GameObject prey;

    [SerializeField]
    private GameObject self;

    [SerializeField]
    private GameObject chaser;

    
    [SerializeField]
    private float speed;

    [SerializeField]
    private float slowDownDistance;

    private Vector3 targetPosition;
    private Vector3 velocity;
    public override void Act()
    {
        ChaseTarget(prey.transform.position);
    }
    private void ChaseTarget(Vector3 target)
    {
        if (target != null)
        {
            //Debug.LogError("chasing!");

            if (chaser.transform.position != target)
            {
                Vector3 distance = (target - chaser.transform.position);

                Vector3 desiredVelocity = (distance.normalized * speed);
                Vector3 steering = desiredVelocity - velocity;

                velocity += steering * Time.deltaTime;

                float slowdownFactor = Mathf.Clamp01(distance.magnitude / slowDownDistance);
                velocity *= slowdownFactor;
                velocity.y = 0;//i don't know why it adds to the y axis
                chaser.transform.position += velocity * Time.deltaTime;

            }

        }
    }
}
