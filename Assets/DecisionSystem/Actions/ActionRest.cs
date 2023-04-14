using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ActionRest : IAction
{
  /// <summary>
  /// restore energy when tired
  /// </summary>

    //the game object with condition tired
    public GameObject eventReceiver;

    public float timeTorest;

   
    public void Play()
    {
        Act();
    }
   
    public override void Act()
    {
        StartCoroutine(nameof(regenEnergy));
    }
   
    private IEnumerator regenEnergy()
    {
        Debug.Log("resting "+ this.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        yield return new WaitForSeconds(timeTorest);
        eventReceiver.GetComponent<ConditionIsTired>().regenEnergy();
    }
}
