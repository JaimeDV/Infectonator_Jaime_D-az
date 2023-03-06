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

    [SerializeField]
    private GameObject humanCollider;


    [SerializeField]
    private GameObject zombie;

    public static event System.Action<GameObject, GameObject> startChase;

    private void Start()
    {
        grid = GetComponent<Grid>();
        calm = true;
    }

    private void Update()
    {
        if (calm)
        {
            timer -= 1 * Time.deltaTime;
            if (timer < 0)
            {
                changePath();
                float random = Random.Range(minTimer, maxTimer);
                timer += random;
            }
        }
    }

    private Node setPaths()
    {
        foreach (Node node in grid.nodeArray)
        {
            float random = Random.Range(0, 10000);
            if (random < 5 && node.isNotWall)
            {
                return node;
            }
        }
        return null;
    }

    private void changePath()
    {
        var newEnd = setPaths();

        if (newEnd != null)
        {
            endpoint.transform.position = newEnd.position;
        }
        else
        {
            changePath();
        }
    }

    private void panic(GameObject target)//all get called , the zombie gets an empty target because it get itself
    {
        Debug.Log("panic target"+target);
        if (target != null)
        {
            if (target.Equals(humanCollider))//for first infection
            {
                calm = false;
                endpoint.transform.position = this.transform.position;
            }
            if (target.Equals(zombie)) //for zombie infections
            {
                calm = false;
                endpoint.transform.position = this.transform.position;
                Debug.Log(target);
                startChase(humanCollider, target);
            }
        }
    }
    private void relax(GameObject target)
    {
        if (target != null)
        {
            if (target.Equals(humanCollider))//for humans 
            {
              
                calm = true;
                
            }
            if (target.Equals(zombie)) //for zombies 
            {
               
                calm = true;
               
            }
        }
    }


    private void OnEnable()
    {
        S_ChaseRange.startchase += panic;
        S_ZombieChase.endchase += relax;
    }

    private void OnDisable()
    {
        S_ChaseRange.startchase -= panic;
        S_ZombieChase.endchase += relax;
    }
}