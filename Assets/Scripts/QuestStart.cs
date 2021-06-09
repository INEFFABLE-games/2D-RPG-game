using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestStart : MonoBehaviour
{
    [SerializeField]
    int QuestNumber;

    [SerializeField]
    Text message;

    [SerializeField]
    Text Sign;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Player")
        {

            if(QuestNumber == 0)
            {
                message.text = "Чапай бульбу ды няси яе да таргоуца!";
                Sign.text = "";
            }
            else if(QuestNumber == 1)
            {
                message.text = "Эй, странник! Мне нужна твоя помошь, доставь это письмо в соседний город Баленос, он находится на северо-востоке отсюда.";
                Sign.text = "";
            }

            other.GetComponent<QuestSystem>().ActiveQuest[QuestNumber] = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        message.text = "";
        Sign.text = "";
    }

}
