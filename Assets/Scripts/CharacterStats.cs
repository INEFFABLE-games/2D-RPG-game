using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class CharacterStats : AbstractCharacter
{

    List<string> enemyNames;

    public GameObject effect;
    public Sprite dead;
    public uint startLevel;
    public GameObject expText;

    void Start()
    {

        multiArmorA = 1;
        multiMagicDamageA = 1;
        multiSpeedA = 1;
        multiWeaponDamageA = 1;

        UpdateStats();
        Health = MaxHealth;
        GenNotify += OnStateChangedNotify;
        DiedNotify += OnDied;
        StartCoroutine(RegenerationHandler());

        name = Name;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(ChangeValue);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Heal(ChangeValue);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            AddMana(ChangeValue);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            AddLevel();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(ChangeValue);
        }

    }

    void OnStateChangedNotify(string name, float value,float fval)
    {
        var text = Instantiate(expText, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        text.transform.SetParent(GameObject.FindGameObjectWithTag("PlayerBar").transform);

        if (name == "exp")
        {

            text.GetComponent<Text>().text = value + " " + name;
            text.transform.position = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
            text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);

            // if (fval >= this.maxExp)
            // {
            //     // this._level++;
            //     // this.exp = fval - exp;
            //     UpdateStats();
            // }
        }
        else if (name == "health")
        {

            if (value >= 0)
            {
                text.GetComponent<Text>().text = value + "hp";
                text.transform.position = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                text.GetComponent<Text>().color = Color.green;

            }
            else if (value < 0)
            {
                text.GetComponent<Text>().text = value + "hp";
                text.transform.position = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                text.GetComponent<Text>().color = Color.red;

            }
        }
        else if (name == "mana" )
        {
            
            if(value >= 0)
            {
                text.GetComponent<Text>().text = + value + "mp";
                text.transform.position = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                text.GetComponent<Text>().color = Color.blue;
                
            }
            else if(value < 0)
            {
                text.GetComponent<Text>().text = + value + "mp";
                text.transform.position = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                text.GetComponent<Text>().color = Color.blue;
            }
        }else
        {
            GameObject.Destroy(text);
        }

    }

    void AddLevel()
    {
        this.level++;
        UpdateStats();
    }

    void AddExp(float val)
    {
        this.exp += val;
    }

    void OnDied(string message)
    {
        Debug.Log(message);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        Instantiate(effect, transform.position, transform.rotation);

        //Destroy(this.gameObject);
    }

}

