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
    private GameObject test;
    [SerializeField]
    private GameObject endpoint;
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
                chased = false;
                endchase(self);
            }
        }
    }

    private void startRunning(GameObject passTarget, GameObject zombie)
    {
        if ( passTarget.Equals(self))//only the human in range runs
        {
            chased = true;
            target = zombie;
        }
    }
    private void Endchase(GameObject passTarget)
    {

        if (chased == true && passTarget.Equals(self))//only the human in range runs
        {
            chased = false;
            target = null;
        }
    }


    private void AvoidTarget(GameObject target)
    {

        if (target != null)
        {
          
            
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

                endpoint.transform.position -= velocity * Time.deltaTime;
                
            }
        }
    }

    private void OnEnable()
    {
        //S_RandomMove.startZombieChase += startRunning;
        S_HumanPanicRange.zombieEnter += startRunning;
        S_HumanPanicRange.zombieExit += Endchase; 
    }

    private void OnDisable()
    {
        //S_RandomMove.startZombieChase -= startRunning;
        S_HumanPanicRange.zombieEnter -= startRunning;
        S_HumanPanicRange.zombieExit -= Endchase; 
    }
  
}