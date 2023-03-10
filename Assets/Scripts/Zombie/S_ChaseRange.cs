using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements.Experimental;
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
    public static event System.Action<GameObject, GameObject> enterRange;
    public static event System.Action<GameObject, GameObject> exitRange;
    public static event System.Action<GameObject, GameObject> remainRange;

    private void OnTriggerEnter(Collider collision)
    {
     
        if (collision.transform.tag.Equals(humantag))
        {
            enterRange(collision.gameObject, self);

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag.Equals(humantag))
        {
            //exitRange(collision.gameObject, self);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag.Equals(humantag))
        {
            remainRange(other.gameObject, self);

        }
    }

}
