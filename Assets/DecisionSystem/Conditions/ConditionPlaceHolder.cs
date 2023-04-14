using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionPlaceHolder : ICondition
{
    /// <summary>
    /// Returns true or false based on a bool no matter what
    /// </summary>

    [SerializeField]
    private bool istrue;
    public override bool Test()
    {
       return istrue;
    }
}
