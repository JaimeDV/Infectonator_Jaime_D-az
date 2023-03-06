using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// start chase behaviour in zombies
/// </summary>
public class S_ChaseRange : MonoBehaviour
{
    private string humantag = "human";
    [SerializeField]
    private SphereCollider sperecoll;
    [SerializeField]
    private GameObject self;
    public static event System.Action<GameObject, GameObject> startchase;
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals(humantag))
        {
            startchase(collision.gameObject, self);
           
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
