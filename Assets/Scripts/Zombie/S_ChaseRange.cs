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
    public static event System.Action<GameObject, GameObject> endchase;


    private void OnTriggerEnter(Collider collision)
    {
     
        if (collision.transform.tag.Equals(humantag))
        {
            startchase(collision.gameObject, self);

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag.Equals(humantag))
        {
            endchase(collision.gameObject, self);

        }
    }

}
