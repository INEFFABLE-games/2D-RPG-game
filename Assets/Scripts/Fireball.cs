using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public GameObject DamageHitter;
    public float lifeTime;
    public GameObject destroyEffect;
    public GameObject earthEffect;
    public GameObject waterEffect;

    private void Start()
    {

        Invoke("DestroyProjectile", lifeTime);

    }

    private void Update()
    {

        //transform.Translate(transform.up * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {
        GameObject a = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        a.GetComponent<CFX_AutoDestructShuriken>().Damager = DamageHitter;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.tag == "Enemy")
            {

            }
            if (other.gameObject.tag == "Earth")
            {
                GameObject eff = Instantiate(earthEffect, transform.position, Quaternion.identity);
            }
            if (other.gameObject.tag == "Water")
            {
                GameObject eff = Instantiate(waterEffect, transform.position, Quaternion.identity);
            }
                DestroyProjectile();

        }


    }

}
