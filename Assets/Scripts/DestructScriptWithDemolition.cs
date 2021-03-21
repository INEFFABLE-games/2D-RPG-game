using UnityEngine;
using System.Collections;

// Cartoon FX  - (c) 2015 Jean Moreno

// Automatically destructs an object when it has stopped emitting particles and when they have all disappeared from the screen.
// Check is performed every 0.5 seconds to not query the particle system's state every frame.
// (only deactivates the object if the OnlyDeactivate flag is set, automatically used with CFX Spawn System)

public class DestructScriptWithDemolition : MonoBehaviour
{

	public float respdealy;	
	public float destdealy;	
	
	IEnumerator Destruct ()
	{
			yield return new WaitForSeconds(destdealy);
					this.gameObject.SetActive(false);
			
	}
	IEnumerator Respawn ()
	{
			yield return new WaitForSeconds(respdealy);
					this.gameObject.SetActive(true);
			
	}

	public void DestructFunc()
	{
		StartCoroutine(nameof(Destruct));
		StartCoroutine(nameof(Respawn));

	}


}
