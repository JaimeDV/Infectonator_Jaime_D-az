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
    public string TargetTag;
    public string AlternativeTag;
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
        if (other.tag.Equals(TargetTag))
        {
            Debug.Log("valid " + this.gameObject.transform.parent.gameObject);
            isNear = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isNear = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals(TargetTag))
        {
            Debug.Log("valid " + this.gameObject.transform.parent.gameObject);
            isNear = true;
        }
    }
}
