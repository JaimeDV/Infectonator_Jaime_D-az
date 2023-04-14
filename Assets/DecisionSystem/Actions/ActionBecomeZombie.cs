using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class ActionBecomeZombie : IAction
{
    
    private List<GameObject> zombies;//zombie polling
    private GameObject holder;
    private GameObject zombieposition;
    [SerializeField]
    private GameObject selfPosition;

    private bool turned;
    private void Awake()
    {
        turned = false;
        holder = this.gameObject.transform.parent.transform.parent.transform.parent.transform.parent.gameObject;
        zombies=new List<GameObject>();
        MovingZombie[] movingZombies = GameObject.FindObjectsOfType<MovingZombie>();
        foreach (var zobie in movingZombies)
        {
            zombies.Add(zobie.gameObject.transform.GetChild(0).gameObject);
        }
        Debug.Log("Zombies count "+zombies.Count);
        //Debug.LogError(holder);
    }
    public override void Act()
    {
        if (!turned)
        {
        foreach (GameObject zombie in zombies)
        {
            if (zombie != null && zombie.activeSelf == false)
            {
                turned=true;
                zombieposition = zombie.transform.GetChild(2).gameObject;
                zombieposition.transform.position = selfPosition.transform.position;
                zombie.SetActive(true);
                break;
            }
        }

        Destroy(holder);

        }
    }
}

