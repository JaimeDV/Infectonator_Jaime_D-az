using UnityEngine;

/// <summary>
/// Defines the infection of the first human, adapted to trigger the condition in the state Machine
/// 
/// </summary>
public class S_InfectTouchStateMachines : MonoBehaviour
{
    private GameObject human;

    [SerializeField]
    private static bool first = true;

    private RaycastHit hit;
    private Ray ray;
    private string humanTag = "human";

    public static event System.Action<GameObject,bool> Touched;

    private void Start()
    {
    }

    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
           // Debug.Log(hit.transform.gameObject);
        }
        if (first && Input.GetMouseButton(0))
        {

            if (hit.transform.tag.Equals(humanTag))
            {
                human = hit.transform.gameObject;
                human = human.transform.parent.gameObject;//get parent
                human = human.transform.parent.gameObject;//get parent

                Touched(human, true);
                

                first = false;
            }
        }
    }
}