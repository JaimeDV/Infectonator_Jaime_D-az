using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Defines the infection of the first human.
/// </summary>
public class S_InfectTouch : MonoBehaviour
{
    [SerializeField]
    private GameObject human;
    [SerializeField]
    private GameObject zombie;
    private static bool first = true;
    void Start()
    {
  
    }

    void Update()
    {
        if (first&& Input.GetMouseButton(0))
        {
            Instantiate(zombie, this.transform.position, Quaternion.identity);
            Destroy(human);
            first = false;
        }
    }
}
