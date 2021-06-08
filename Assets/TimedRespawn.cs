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



        GameObject newChar = null;
        switch (type)
        {
            case "Settlement":
                yield return new WaitForSeconds(resptime);
                newChar = Instantiate(Templates[(int)Tplates.Settlement], spawnPosition, transform.rotation);
                break;

            case "Knight":
                yield return new WaitForSeconds(resptime);
                newChar = Instantiate(Templates[(int)Tplates.Knight], spawnPosition, transform.rotation);
                break;

            case "Player":
                //newChar = Instantiate(Templates[(int)Tplates.Player], spawnPosition, transform.rotation);
                GameObject plr = GameObject.FindGameObjectWithTag("Player");
                plr.GetComponent<PlayerMovement>().canMove = false;

                yield return new WaitForSeconds(resptime);

                plr.GetComponent<PlayerMovement>().canMove = true;
                plr.transform.position = spawnPosition;
                plr.transform.rotation = transform.rotation;
                plr.GetComponent<AbstractCharacter>().Health = 99999999;


                break;
            default:
                yield break;
        }
        if (newChar != null)
        newChar.GetComponent<AbstractCharacter>().respawnPosition = spawnPosition;
    }

    public void Respawn(float resptime, Vector3 spawnPosition, string charType)
    {
        StartCoroutine(Debounce(resptime, spawnPosition, charType));
    }

}
