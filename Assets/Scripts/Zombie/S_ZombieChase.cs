using UnityEngine;

public class S_ZombieChase : MonoBehaviour
{/// <summary>
/// chase behaviour in zombies
/// </summary>
    private bool chasing;

    private GameObject target;
    private float timer;

    //[SerializeField]
    //private GameObject test;

    [SerializeField]
    private Grid grid;
    [SerializeField]
    private GameObject self;

    [SerializeField]
    private GameObject zombie;

    [SerializeField]
    private float nodeAprox;//how close should be a object to a node to be considered in it
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

  
    private void Update()
    {
       
        if (chasing)
        {
            Debug.Log(this.gameObject.transform.parent + "  " + target);
            if (target != null)
            {
                ChaseTarget(target.transform.position);
            }
            else
            {
                endchase(self);
            }
        }
    }

    private void startchase(GameObject passTarget, GameObject zombie)
    {
        if (target == null)
        {
            if (zombie.Equals(self))//only the zombie in range chases
            {
                chasing = true;
                target = passTarget;
            }

        }
    }

    private void ChaseTarget(Vector3 target)
    {
        if (target != null)
        {

            if (zombie.transform.position != target)
            {
                Vector3 distance = (target - zombie.transform.position);

                Vector3 desiredVelocity = (distance.normalized * speed);
                Vector3 steering = desiredVelocity - velocity;

                velocity += steering * Time.deltaTime;

                float slowdownFactor = Mathf.Clamp01(distance.magnitude / slowDownDistance);
                velocity *= slowdownFactor;
                velocity.y = 0;//i don't know why it adds to the y axis
                zombie.transform.position += velocity * Time.deltaTime;

            }

        }
    }
    private void FindNode(GameObject target)
    {
        //Instantiate(test, target.transform.position, Quaternion.identity);
        foreach (Node node in grid.nodeArray)
        {

            //Vector3 distance = (target.transform.position - node.position);
            //Debug.Log(distance);
            //distance += nodeAprox;
            //getMagnitued(distance);
            //Debug.Log(Vector3.Distance(distance, node.position));
         
            if (Vector3.Distance(target.transform.position, node.position)<nodeAprox && node.isNotWall)
            {
                //Instantiate(test, target.transform.position, Quaternion.identity);
                //target.transform.position= node.position;
                ChaseTarget(node.position);
                break;
            }
            
        }


        endchase(self);
    }
   
    private void OnEnable()
    {
        S_RandomMove.startZombieChase += startchase;
        S_ChaseRange.remainRange += startchase;
    }

    private void OnDisable()
    {
        S_RandomMove.startZombieChase -= startchase;
        S_ChaseRange.remainRange += startchase;
    }
}