using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// plays a particle on infection an spawns a new zombie, zombies are polled before
/// </summary>
public class S_particlePlay : MonoBehaviour
{
    [SerializeField]
    private GameObject self;
    [SerializeField]
    private GameObject selfPosition;
    [SerializeField]
    private GameObject collider;
    [SerializeField]
    private ParticleSystem parti;
    [SerializeField]
    private GameObject mover;
    [SerializeField]
    private List<GameObject> zombies;//zombie polling 
   
    private GameObject zombieposition;
    private bool infected;
    private void Start()
    {
        infected = false; 
    }
    private void particleplay(GameObject human)
    {
        if (human.Equals(self))//for first infection
        {
            parti.Play();
            Destroy(mover);
            infected=true;

        }
        if (human.Equals(collider)) //for zombie infections
        {
            parti.Play();
            Destroy(mover);
            infected = true;
        }
    }
    private void Update()
    {
        if (parti.isStopped && infected==true)//set a new zombie after infection
        {
            foreach(GameObject zombie in zombies)
            {
                if (zombie.activeSelf == false)
                {
                    zombieposition = zombie.transform.GetChild(2).gameObject;
                    zombieposition.transform.position = selfPosition.transform.position;
                    zombie.SetActive(true);
                    break;

                }
            }

            Destroy(self);
        }
    }
    private void OnEnable()
    {
        S_InfectTouch.KillHuman += particleplay;
        S_InfectRange.infect +=particleplay;    
    }
    private void OnDisable()
    {
        S_InfectTouch.KillHuman -= particleplay;
        S_InfectRange.infect -= particleplay;
    }
}
