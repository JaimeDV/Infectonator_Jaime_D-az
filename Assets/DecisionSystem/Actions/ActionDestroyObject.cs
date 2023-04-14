using UnityEngine;
using System.Collections;

/// <summary>
/// Destroys an object
/// </summary>
public class ActionDestroyObject : IAction
{
	public GameObject objectToDestroy;


	public override void Act ()
	{
		Debug.Log("killing!");
		if (objectToDestroy == null)	return;

		Destroy(objectToDestroy);
	}
}
