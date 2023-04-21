using UnityEngine;

public class ActionRunToTrigger : IAction
{
    [SerializeField]
    private GameObject target;

    private float timer;

    [SerializeField]
    private GameObject endpoint;

    [SerializeField]
    private GameObject chaser;

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

    public string TargetTag;

    public override void Act()
    {
        if (moveScript != null)
        {
            moveScript.enabled = true;
        }

        if (target != null)
        {
        ChaseTarget(target.transform.position);

        }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals(TargetTag))
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(TargetTag))
        {
            target = other.gameObject;
        }
    }
}
