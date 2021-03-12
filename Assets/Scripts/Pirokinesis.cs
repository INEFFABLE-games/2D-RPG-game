using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirokinesis : MagicManager
{
   
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    public float DebounceTime;
    private float timeBtwCast;
    public float startTimeBtwCast;
    public LayerMask Eff;
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotZ + offset);
        Shoot();
        if (timeBtwCast <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(shotPoint.position);
                Instantiate(projectile, shotPoint.position, transform.rotation);
            }
        }
        else
        {
            timeBtwCast -= Time.deltaTime;
        }
        
    }

    public void Shoot()
    {
        Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x ,Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
        Vector2 firePointPos = new Vector2 (shotPoint.position.x, shotPoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPos,mousePos - firePointPos, 100, Eff);
        for(var i = 0;i < 360;i++)
        {   
            Debug.DrawRay(firePointPos, (firePointPos - mousePos) * 10, Color.magenta);
        }
        
    } 


}

