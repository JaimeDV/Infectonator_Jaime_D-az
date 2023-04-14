using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// checks if the the target of the tree is a prey or not
/// </summary>
public class ConditionIsPrey : ICondition
{
    [SerializeField]
    private string preyTag = "Prey";
    [SerializeField]
    private GameObject masterGameObject;
    public override bool Test()
    {
     
        if (masterGameObject!=null && masterGameObject.tag.Equals(preyTag))
        {
            return true;
        }
        return false;
    }

}
