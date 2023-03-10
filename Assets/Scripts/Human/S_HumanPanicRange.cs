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
    public static event System.Action<GameObject, GameObject> zombieEnter;
    public static event System.Action<GameObject> zombieExit;


   
    //private void OnCollisionEnter(Collision collision)
    //{
        
    //    if (collision.transform.tag.Equals(zombietag))
    //    {
         
    //        if (self != null && zombieEnter!=null)
    //        {
    //        zombieEnter(self, collision.gameObject);

    //        }

    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals(zombietag))
        {

            if (self != null && zombieEnter != null)
            {
                zombieEnter(self, other.gameObject);

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.transform.tag.Equals(zombietag))
        {

            if (self != null && zombieExit != null)
            {
                Debug.Log("back to normal");
                //zombieExit(self);

            }

        }
    }
    //private void OnCollisionExit(Collision collision)
    //{
       
    //    if (collision.transform.tag.Equals(zombietag))
    //    {
           
    //        if (self != null&& zombieExit!=null)
    //        {
    //            Debug.Log("back to normal");
    //            //zombieExit(self);

    //        }

    //    }
    //}
   
}
