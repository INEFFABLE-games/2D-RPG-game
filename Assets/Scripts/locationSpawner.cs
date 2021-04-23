using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationSpawner : MonoBehaviour
{

    IEnumerator SpawnNewLoc()
    {
        if (canSpawn)
        {
            Debug.Log("Spawning...");
            canSpawn = false;
            if (location != null)
                GameObject.Destroy(location);

            yield return new WaitForSeconds(Random.Range(5, 10));

            location = Instantiate(locations[Random.Range(0, locations.Count)], new Vector3(transform.position.x, transform.position.y), transform.rotation);
        }
        yield return new WaitForSeconds(Random.Range(120,420));
        canSpawn = true;

        yield break;
    }

    [SerializeField]
    List<GameObject> locations;

    [SerializeField]
    GameObject location;

    [SerializeField]

    bool canSpawn;

    void Start()
    {
        canSpawn = true;
    }

    void Update()
    {
        if(canSpawn)
        StartCoroutine(SpawnNewLoc());
        
    }
}
