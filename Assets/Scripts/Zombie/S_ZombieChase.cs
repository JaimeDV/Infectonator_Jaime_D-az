using UnityEngine;

public class S_ZombieChase : MonoBehaviour
{/// <summary>
/// chase behaviour in zombies
/// </summary>
    private bool chasing;

    private GameObject target;
    private float steeps;
    private float timer;
    private float startDelay;

    [SerializeField]
    private GameObject self;

    private Vector3 startPosition;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float slowDownDistance;

    private Vector3 targetPosition;
    private Vector3 velocity;

    public static event System.Action<GameObject> endchase;

    private void Start()
    {
        chasing = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (chasing)
        {
            if (target != null)
            {
                Debug.Log("target!");
                chaseTarget(target);
            }
            else
            {
                endchase(self);
            }
        }
    }

    private void startchase(GameObject passTarget, GameObject zombie)
    {
        Debug.Log("pass " + passTarget);
        if (zombie.Equals(self))//only the zombie in range chases
        {
            chasing = true;
            target = passTarget;
        }
    }

    private void chaseTarget(GameObject target)
    {
        if (target != null)
        {
            timer += Time.deltaTime * speed;
            targetPosition = target.transform.position;
            if (self.transform.position != targetPosition)
            {
                Vector3 distance = (targetPosition - self.transform.position);

                Vector3 desiredVelocity = (distance.normalized * speed);
                Vector3 steering = desiredVelocity - velocity;

                velocity += steering * Time.deltaTime;

                float slowdownFactor = Mathf.Clamp01(distance.magnitude / slowDownDistance);
                velocity *= slowdownFactor;
                velocity.y = 0;//i don't know why it adds to the y axis
                self.transform.position += velocity * Time.deltaTime;
                //player.transform.position = Vector3.Lerp(startPosition, cuarrentNodeDistance, timer);
            }
        }
    }

    private void OnEnable()
    {
        S_RandomMove.startChase += startchase;
    }

    private void OnDisable()
    {
        S_RandomMove.startChase -= startchase;
    }
}