using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAQScript : MonoBehaviour
{
    [SerializeField]
    Text tipText;

    List<string> tips;
    int _tip;

    void Start()
    {
        tips = new List<string>()
        {
        "1: Исспользуйте клавишу \"R\" для активации/деактивации магии.",
        "2: Исспользуйте клавишу \"I\" для открытия/закрытия инфентаря персонажа.",
        "3: Исспользуйте клавиши \"WASD\" для перемещения персонажа.",
        "4: Исспользуйте левую клавишу мыши при активированной магии для атаки.",
        "5: Для прохождения игры исследуйте мир и выполняте квесты.",
        };

        _tip = 0;
        StartTips();
    }

    void StartTips()
    {
        tipText.text = tips[_tip];

    }

    public void NextTip()
    {
        _tip++;
        if (_tip == tips.Count+1)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Find("FAQ").gameObject.SetActive(false);
            return;
        }
        StartTips();
    }

}
