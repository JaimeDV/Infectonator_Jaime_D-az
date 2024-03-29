using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Using A A* star grid guides movement towards an already defined objective
/// </summary>
public class S_ModePlayer : MonoBehaviour
{
    [SerializeField]
    private Grid grid;

    [SerializeField]
    private GameObject endPoint;

    private Node cuarrentNode;
    private int nodePosition;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject self;

    private float steeps;
    private float timer;
    private float startDelay;
    private Vector3 startPosition;
    private List<Node> finalPath;

    [SerializeField]
    private float speed;

    private bool calm;

    [SerializeField]
    private bool human;

    [SerializeField]
    private float slowDownDistance;

    private Vector3 cuarrentNodeDistance;
    private Vector3 velocity;

    public static System.Action <Vector3, Vector3> generateFinal;

    private void Start()
    {
        calm = true;
        grid = GetComponent<Grid>();
        finalPath = grid.FinalPath;
        CheckNode();
        velocity = Vector3.zero;
    }

    private void Update()
    {
        if (calm)
        {
            startDelay++;
            startDelay += Time.deltaTime;
            if (startDelay > 5)
            {
                //grid = GetComponent<Grid>();
                finalPath = grid.FinalPath;
                //finalPath = S_Pathfinding.
                CheckNode();
            }
            MoveToTarget();
        }
        else if (human)
        {
            //grid = GetComponent<Grid>();
            finalPath = grid.FinalPath;
            CheckNode();
            MoveToTarget();
        }
    }

    private void CheckNode()
    {
        if (finalPath != null && finalPath.Count > 0)
        {
            timer = 0;
            startPosition = player.transform.position;
            cuarrentNodeDistance = finalPath[nodePosition].position;
        }
    }

    private void MoveToTarget()
    {
        if (finalPath != null && finalPath.Count > 0)//should change it so it continues moving
        {
            timer += Time.deltaTime * speed;

            if (player.transform.position != cuarrentNodeDistance)
            {
                Vector3 distance = (cuarrentNodeDistance - player.transform.position);

                Vector3 desiredVelocity = (distance.normalized * speed);
                Vector3 steering = desiredVelocity - velocity;
                
                velocity += steering * Time.deltaTime;

                float slowdownFactor = Mathf.Clamp01(distance.magnitude / slowDownDistance);
                velocity *= slowdownFactor;
                velocity.y = 0;//i don't know why it adds to the y axis
                player.transform.position += velocity * Time.deltaTime;
                //player.transform.position = Vector3.Lerp(startPosition, cuarrentNodeDistance, timer);
            }
            else
            {
                if (nodePosition < finalPath.Count - 1)
                {
                    nodePosition++;
                    CheckNode();
                }
            }
        }
    }

    public void resetTimer()
    {
        startDelay = 0;
    }

    public void setEndpoint()
    {
    }

    private void panic(GameObject target, GameObject zombie)
    {
        if (target != null)
        {
            if (self.Equals(target))//for humans
            {
                calm = false;
            }
            if (self.Equals(zombie))
            {
                calm = false;
            }
        }
    }

    private void Relax(GameObject target)
    {
        if (target != null)
        {
            if (self.Equals(target))//for humans
            {
                calm = true;
            }
        }
    }

    private void OnEnable()
    {
        S_ChaseRange.enterRange += panic;
        S_ChaseRange.exitRange += panic;
        S_ZombieChase.endchase += Relax;
        S_PanicHuman.endchase += Relax;
    }

    private void OnDisable()
    {
        S_ChaseRange.enterRange -= panic;
        S_ChaseRange.exitRange -= panic;
        S_ZombieChase.endchase -= Relax;
        S_PanicHuman.endchase -= Relax;
    }
}