using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Checks if this transform is within "range" distance from "target"
/// </summary>
public class ConditionTargetNear : ICondition
{
	/// <summary>
	/// Target to detect
	/// </summary>
	public Transform target;
	public List<Transform> targets;
    private static GameObject nearTarget;

    /// <summary>
    /// The maximun range a target can be detected
    /// </summary>
    public float range = 5.0f;
	
	
	public override bool Test ()
	{

		if (target == null) return false;

		return (transform.position - target.transform.position).magnitude <= range;

		//foreach(Transform t in targets)
		//{
		//	if((transform.position - t.transform.position).magnitude <= range){
		//              Debug.Log("found one!");
		//		nearTarget = t.transform.gameObject;
		//              return true;
		//	}
		//}
		//return false;
	}
	public GameObject GetTarget()
	{
		return nearTarget;
	}

}
