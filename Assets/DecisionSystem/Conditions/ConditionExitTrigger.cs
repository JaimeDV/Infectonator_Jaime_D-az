using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionExitTrigger : ICondition
{
    public bool isNotNear;
    public string TargetTag;
    public string AlternativeTag;
    public override bool Test()
    {
        if (isNotNear)
        {
            return true;
        }
        return false;
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals(TargetTag))
        {
            isNotNear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(TargetTag))
        {
            isNotNear = false;
        }
    }
}
