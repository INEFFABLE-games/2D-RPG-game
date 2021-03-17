﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

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
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            DestroyProjectile();
        }
        if(other.gameObject.tag == "Earth")
        {
            GameObject eff = Instantiate(earthEffect,transform.position, Quaternion.identity);
            DestroyProjectile();
        }
        if(other.gameObject.tag == "Water")
        {
            GameObject eff = Instantiate(waterEffect,transform.position, Quaternion.identity);
            DestroyProjectile();
        }
    }

}
