using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
/// <summary>
/// the same as is near but with a fixed lenght.
/// I need to make this because is near doesn't work when there is a second one
/// </summary>
public class ConditionEnterTrigger : ICondition
{
    public bool isNear;
    public string preyTag;
    public override bool Test()
    {
        if (isNear)
        {
            return true;
        }
        return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("trigger!");
        if (other.tag.Equals(preyTag))
        {
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
}
