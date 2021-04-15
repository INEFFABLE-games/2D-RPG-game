using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRespawn : MonoBehaviour
{

    enum Tplates
    {
        Settlement,
        Knight,
        Player

    }

    [SerializeField] GameObject[] Templates;

    IEnumerator Debounce(float resptime, Vector3 spawnPosition, string type)
    {

        yield return new WaitForSeconds(resptime);
        GameObject newChar = null;
        switch (type)
        {
            case "Settlement":
                newChar = Instantiate(Templates[(int)Tplates.Settlement], spawnPosition, transform.rotation);
                break;

            case "Knight":
                newChar = Instantiate(Templates[(int)Tplates.Knight], spawnPosition, transform.rotation);
                break;

            case "Player":
                newChar = Instantiate(Templates[(int)Tplates.Player], spawnPosition, transform.rotation);
                break;
            default:
                yield break;
        }
        newChar.GetComponent<AbstractCharacter>().respawnPosition = spawnPosition;
    }

    public void Respawn(float resptime, Vector3 spawnPosition, string charType)
    {
        StartCoroutine(Debounce(resptime, spawnPosition, charType));
    }

}
