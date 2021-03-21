using UnityEngine;
using System.Collections;

// Cartoon FX  - (c) 2015 Jean Moreno

// Automatically destructs an object when it has stopped emitting particles and when they have all disappeared from the screen.
// Check is performed every 0.5 seconds to not query the particle system's state every frame.
// (only deactivates the object if the OnlyDeactivate flag is set, automatically used with CFX Spawn System)

[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
	// If true, deactivate the object instead of destroying it
	public bool OnlyDeactivate;
	
	void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
	}

	IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

	IEnumerator CheckIfAlive ()
	{
		ParticleSystem ps = this.GetComponent<ParticleSystem>();
		CircleCollider2D coll = this.gameObject.GetComponent<CircleCollider2D>();
		while(true && ps != null)
		{
			yield return new WaitForSeconds(0.2f);
			
			if(coll)
			coll.enabled = false;

			if(!ps.IsAlive(true))
			{
				if(OnlyDeactivate)
				{
					#if UNITY_3_5
						this.gameObject.SetActiveRecursively(false);
					#else
						this.gameObject.SetActive(false);
					#endif
				}
				else
					GameObject.Destroy(this.gameObject);
				break;
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D other) 
	{
		
		if(other.gameObject.tag == "Destructable")
		{
			Debug.Log("XУЙ");
			other.gameObject.GetComponent<DestructScriptWithDemolition>().DestructFunc();
		}
		if (other.gameObject.tag == "Enemy")
        {
			Random rnd = new Random();
			var Player = GameObject.FindWithTag("Player");
			float dmg = Player.GetComponent<CharacterStats>().magicLevel + UnityEngine.Random.Range(1,50);
			other.gameObject.GetComponent<EnemyStats>().TakeDamage(dmg);

        }

	}

}
