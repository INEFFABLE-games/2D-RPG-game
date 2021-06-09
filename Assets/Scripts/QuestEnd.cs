using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestEnd : MonoBehaviour
{
    [SerializeField]
    int QuestNumber;

    [SerializeField]
    Text message;

    [SerializeField]
    Text Sign;

    [SerializeField]
    GameObject item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {

            if (other.GetComponent<QuestSystem>().ActiveQuest[QuestNumber] == true)
            {

                if (QuestNumber == 0)
                {
                    message.text = "Спасибо, вот награда за твои труды!";
                    Sign.text = "";

                    GameObject newitm = Instantiate(item,transform.position + new Vector3(0,-1,0),transform.rotation);
                    newitm.GetComponent<AbstractItem>().Amount = 2;

                }
                else if (QuestNumber == 1)
                {
                    message.text = "Спасибо, это письмо очень важно! Держи награду.";
                    Sign.text = "";

                    GameObject newitm = Instantiate(item,transform.position + new Vector3(0,-1,0),transform.rotation);
                    //newitm.GetComponent<AbstractItem>().Amount = 1;

                }

                other.GetComponent<QuestSystem>().ActiveQuest[QuestNumber] = false;
                other.GetComponent<QuestSystem>().CompletedQuest[QuestNumber] = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        message.text = "";
        Sign.text = "";
    }

}
