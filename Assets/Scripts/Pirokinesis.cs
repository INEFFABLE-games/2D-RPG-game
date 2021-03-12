using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirokinesis : MagicManager
{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwCast;
    public float startTimeBtwCast;
    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float RotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotZ + offset);

        if (timeBtwCast <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
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



}
