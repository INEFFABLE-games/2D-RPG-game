using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRespawn : MonoBehaviour
{

    enum Tplates
    {
        Settlement,
        Knight,
        Player,
        DarkKnight

    }

    [SerializeField] GameObject[] Templates;

    IEnumerator Debounce(float resptime, Vector3 spawnPosition, string type, GameObject plr)
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

            case "DarkKnight":
                yield return new WaitForSeconds(resptime);
                newChar = Instantiate(Templates[(int)Tplates.DarkKnight], spawnPosition, transform.rotation);
                break;

            case "Player":
                //newChar = Instantiate(Templates[(int)Tplates.Player], spawnPosition, transform.rotation);

                uint level = plr.GetComponent<AbstractCharacter>().level;
                float rep = plr.GetComponent<AbstractCharacter>().reputation;

                GameObject.Destroy(plr);

                yield return new WaitForSeconds(resptime);

                newChar = Instantiate(Templates[(int)Tplates.Player], spawnPosition, transform.rotation);

                newChar.transform.position = spawnPosition;
                newChar.transform.rotation = transform.rotation;
                newChar.GetComponent<AbstractCharacter>().level = level;
                newChar.GetComponent<AbstractCharacter>().reputation = rep;

                break;
            default:
                yield break;
        }
        if (newChar != null)
            newChar.GetComponent<AbstractCharacter>().respawnPosition = spawnPosition;
    }

    public void Respawn(float resptime, Vector3 spawnPosition, string charType, GameObject thisObj)
    {
        StartCoroutine(Debounce(resptime, spawnPosition, charType, thisObj));
    }

}
