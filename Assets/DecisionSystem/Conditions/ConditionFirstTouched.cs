using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionFirstTouched : ICondition
{
    private GameObject holder;

    private bool toKill;

    private GameObject target;

    private void Awake()
    {
        holder = this.gameObject.transform.parent.transform.parent.transform.parent.gameObject;
    }
    public override bool Test()
    {

        if (this.target != null && this.target==holder && toKill==true)
        {
            return true;
        }
        return false;
    }

    public void IsInfected(GameObject target, bool value)
    {
        this.target = target;
        if (target == holder)
        {
            toKill = true;
        }
    }
    private void OnEnable()
    {
        S_InfectTouchStateMachines.Touched += IsInfected;
    }
    private void OnDisable()
    {
        S_InfectTouchStateMachines.Touched -= IsInfected;
    }

}
