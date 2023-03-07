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
  
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision);
        if (collision.transform.tag.Equals(humantag))
        {
            startchase(collision.gameObject, self);

        }
    }

}
