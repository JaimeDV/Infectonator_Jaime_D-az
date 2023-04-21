using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChangeRandomMove : IAction
{
    [SerializeField]
    public bool deactivateInsted;

    [SerializeField]
    private S_RandomMoveMachine moveScript;

    public override void Act()
    {
        if (deactivateInsted)
        {
           
            if (moveScript != null)
            {
                moveScript.enabled = false;
            }
        }
        else
        {
            if (moveScript != null)
            {
                moveScript.enabled = true;
            }

        }
    }
}
