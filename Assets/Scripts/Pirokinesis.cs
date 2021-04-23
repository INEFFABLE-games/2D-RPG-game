using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirokinesis : MagicManager
{
   
    public float offset;
    public GameObject projectile;
    public float projSpeed;
    public Transform shotPoint;
    public float DebounceTime;
    public float timeBtwCast;
    public LayerMask Eff;
    public GameObject Player;

    private void Update()
    {
        
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotZ + offset);

        Vector3 difference = target;
        float rotationZ = Mathf.Atan2(difference.y,difference.x) * Mathf.Rad2Deg;



        if (timeBtwCast <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                timeBtwCast = DebounceTime;
                if(Player.GetComponent<CharacterStats>().mana - ManaCost >= 0 && GameObject.FindGameObjectWithTag("Player").GetComponent<AbstractCharacter>().CanShoot)
                {
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    Shoot(direction, rotationZ);
                }
                else
                {
                }
            }
        }
        else
        {
            timeBtwCast -= Time.deltaTime;
            //Debug.Log(timeBtwCast);
        }
    }
        
    

    public void Shoot(Vector2 direction, float rotationZ)
    {
        Player.GetComponent<CharacterStats>().mana -= ManaCost;
        GameObject proj = Instantiate(projectile, shotPoint.position, transform.rotation);
        proj.GetComponent<Rigidbody2D>().velocity = direction * projSpeed;
        Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x ,Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
        Vector2 firePointPos = new Vector2 (shotPoint.position.x, shotPoint.position.y);

        proj.GetComponent<Fireball>().DamageHitter = Player;

    } 


}

