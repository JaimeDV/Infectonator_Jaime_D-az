using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ChaseRange : MonoBehaviour
{
    private string humantag = "human";
    [SerializeField]
    private SphereCollider sperecoll;
    [SerializeField]
    private GameObject self;
    public static event System.Action<GameObject> startchase;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals(humantag))
        {
            startchase(collision.gameObject);
            startchase(self);
        }
    }
    private void OnDrawGizmos()
    {
        if (sperecoll != null)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(this.transform.position, sperecoll.radius);

        }
    }
}
