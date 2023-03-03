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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals(humantag))
        {
            infect(collision.gameObject);
        }
    }
    private void OnDrawGizmos() {
        if (sperecoll != null)
        {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(this.transform.position,sperecoll.radius);

        }
    }
}
