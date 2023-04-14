using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ConditionPreyTipe : ICondition
{
    /// <summary>
    /// Cut
    /// checks the type of animal that is nearby
    /// </summary>
    public string preyTag;
    //the one with condition targetnear
    //public GameObject eventReceiver;
    public GameObject target;
    public override bool Test()
    {
        //target=eventReceiver.GetComponent<ConditionTargetNear>().GetTarget();
        

        if (target == null)		return false;

        if (target.tag.Equals(preyTag)){
            return true;
        }
        else
        {
            return false;
        }
        //return (transform.position - target.transform.position).magnitude <= range;

    }
}
