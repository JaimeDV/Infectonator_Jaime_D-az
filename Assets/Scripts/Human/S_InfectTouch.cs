using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Defines the infection of the first human.
/// </summary>
public class S_InfectTouch : MonoBehaviour
{
    private GameObject human;
    [SerializeField]
    private static bool first = true;
    private RaycastHit hit;
    private Ray ray;
    private string humanTag = "human";
    public static event System.Action<GameObject> KillHuman;
    void Start()
    {
        
     }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {

        }
        if (first&& Input.GetMouseButton(0))
        {
            if (hit.transform.tag.Equals(humanTag))
            {
            human = hit.transform.gameObject;
            
            human = human.transform.parent.gameObject;
            human = human.transform.parent.gameObject;//get to parent
            KillHuman(human);
            
            first = false;
            }
         
              
        }
    }
}
