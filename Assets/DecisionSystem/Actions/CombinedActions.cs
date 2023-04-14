using UnityEngine;
using System.Collections;

/// <summary>
/// Combines more than one action in the same execution
/// </summary>
public class CombinedActions : IAction
{
	public IAction[] actions;

	
	public override void Act ()
	{
		for (int i = 0; i < actions.Length; ++i)
		{
			actions[i].Act();
		}
	}

	public override void InitializeAction ()
	{
		Debug.Log("acting!");
		for (int i = 0; i < actions.Length; ++i)
		{
			actions[i].InitializeAction();
		}
	}
	
	
	public override void FinalizeAction ()
	{
		Debug.Log("acting!");
		for (int i = 0; i < actions.Length; ++i)
		{
			actions[i].FinalizeAction();
		}
	}

}
