using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_HumanPanicRange : MonoBehaviour
{
    private string zombietag = "Zombie";
    [SerializeField]
    private SphereCollider sperecoll;
    [SerializeField]
    private GameObject self;
    public static event System.Action<GameObject, GameObject> startchase;
    public static event System.Action<GameObject> endchase;


   
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.tag.Equals(zombietag))
        {
         
            if (self != null && startchase!=null)
            {
            startchase(self, collision.gameObject);

            }

        }
    }
    private void OnCollisionExit(Collision collision)
    {
       
        if (collision.transform.tag.Equals(zombietag))
        {
           
            if (self != null&& endchase!=null)
            {
                Debug.Log("back to normal");
                endchase(self);

            }

        }
    }
   
}
