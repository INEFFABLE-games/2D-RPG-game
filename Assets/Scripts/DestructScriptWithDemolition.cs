using UnityEngine;
using System.Collections;

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
		StartCoroutine(Destruct());
		StartCoroutine(Respawn());

	}


}
