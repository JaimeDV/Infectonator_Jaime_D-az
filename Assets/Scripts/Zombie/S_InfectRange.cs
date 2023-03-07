using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_InfectRange : MonoBehaviour
{

    private string humantag = "human";
    public static event System.Action<GameObject> infect;
    [SerializeField]
    private SphereCollider sperecoll;
    void Start()
    {
        sperecoll = GetComponent<SphereCollider>();
    }

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("infect collision");
        if (other.transform.tag.Equals(humantag))
        {
            infect(other.gameObject);
        }
    }
   

}
