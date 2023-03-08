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
    private GameObject self;

    public static event System.Action<GameObject, GameObject> startZombieChase;

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

    private void Panic(GameObject target, GameObject zombie)//all get called , the zombie gets an empty target because it get itself
    {

        if (target != null)
        {
            if (self.Equals(target))//for humans
            {
                calm = false;
                endpoint.transform.position = this.transform.position;
            }
            if (self.Equals(zombie))
            {
                calm = false;
                endpoint.transform.position = this.transform.position;
                startZombieChase(target, zombie);
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
        S_ChaseRange.startchase += Panic;
        S_ZombieChase.endchase += Relax;
        S_PanicHuman.endchase += Relax;
        S_HumanPanicRange.endchase += Relax;
    }

    private void OnDisable()
    {
        S_ChaseRange.startchase -= Panic;
        S_ZombieChase.endchase -= Relax;
        S_PanicHuman.endchase -= Relax;
        S_HumanPanicRange.endchase -= Relax;
    }
}