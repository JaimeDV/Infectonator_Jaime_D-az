using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;


/// <summary>
/// a variant of wait for second adapted to stateMachines
/// </summary>
public class ConditionWaitSeconds : ICondition
{
    [SerializeField]
    private ParticleSystem particles;

    private float timer;

    [SerializeField]
    private float timerLimit;

    private void Awake()
    {
        timer = timerLimit;
    }
    void Update()
    {
        //Debug.Log(timer);
        if (particles != null&& particles.isPlaying)
        {
            timer -= Time.deltaTime;
        }
    }
    public override bool Test()
    {
        if (timer<=0)
        {
            return true;
        }
        return false;
    }
}
