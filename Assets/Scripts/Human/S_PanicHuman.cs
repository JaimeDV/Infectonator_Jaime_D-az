using UnityEngine;

/// <summary>
/// panic behaviour in humans
/// </summary>
public class S_PanicHuman : MonoBehaviour
{
    private bool chased;

    private GameObject target;
    private float timer;

    [SerializeField]
    private GameObject self;

    [SerializeField]
    private GameObject human;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float slowDownDistance;

    private Vector3 targetPosition;
    private Vector3 velocity;

    public static event System.Action<GameObject> endchase;
    private void Start()
    {
        chased = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (chased)
        {
            if(target != null)
            {
            AvoidTarget(target);

            }
            else
            {
                endchase(self);
            }
        }
    }

    private void startchase(GameObject passTarget, GameObject zombie)
    {
      
        if (passTarget.Equals(self))//only the human in range runs
        {
            chased = true;

            Debug.Log(passTarget.transform.position);

            target = zombie;
        }
    }

    private void AvoidTarget(GameObject target)
    {

        if (target != null)
        {
            Debug.Log("human panic!");
            Debug.Log(target);
            Debug.Log(target.transform.position);
            timer += Time.deltaTime * speed;
            targetPosition = target.transform.position;
            if (human.transform.position != targetPosition)
            {
                Vector3 distance = (targetPosition - human.transform.position);

                Vector3 desiredVelocity = (distance.normalized * speed);
                Vector3 steering = desiredVelocity - velocity;

                velocity += steering * Time.deltaTime;

                float slowdownFactor = Mathf.Clamp01(distance.magnitude / slowDownDistance);
                velocity *= slowdownFactor;
                velocity.y = 0;//i don't know why it adds to the y axis
                
                human.transform.position -= velocity * Time.deltaTime;

            }
        }
    }

    private void OnEnable()
    {
        S_RandomMove.startZombieChase += startchase;
    }

    private void OnDisable()
    {
        S_RandomMove.startZombieChase -= startchase;
    }
}