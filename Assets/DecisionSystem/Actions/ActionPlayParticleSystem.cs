using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.VirtualTexturing;

/// <summary>
/// Starts playing/stops a particle system.
/// </summary>
public class ActionPlayParticleSystem : IAction
{
	public ParticleSystem particleSystemToPlay;
	public bool stopInstead = false;
	
	public override void Act ()
	{
		if (stopInstead)
		{
			//particleSystemToPlay.Stop();
			
            particleSystemToPlay.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
		else
		{
			if (!particleSystemToPlay.isPlaying)
			{
				particleSystemToPlay.Play();
			}
		}
	}
	
	public void Play ()
	{
		Act();
	}
	
	
}
