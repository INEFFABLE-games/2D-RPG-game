﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class CharacterStats : AbstractCharacter
{

    List<string> enemyNames;

    public GameObject effect;
    public Sprite dead;
    public Vector3 respawnPoint;
    public uint startLevel;
    public GameObject expText;

    void Start()
    {
        UpdateStats();
        Health = MaxHealth;
        GenNotify += OnStateChangedNotify;
        DiedNotify += OnDied;
        StartCoroutine(RegenerationHandler());
        level = startLevel;

        if (this.gameObject.tag == "Enemy")
            level += (uint)Random.Range(1, 20);

        name = Name;

        enemyNames = new List<string>()
        {
            "Ruthe",
            "Stephanie",
            "Shanie",
            "Camille",
            "Lesly",
            "Daisy",
            "Dedric",
            "Manley",
            "Dorian",
            "Leola",
            "Kaitlin",
            "Emie",
            "Dandre",
            "Stacey",
            "Caroline",
            "Sabina",
            "Erwin",
            "Victoria",
            "Carrie",
            "Ramon",
            "Amira"
        };
        if (this.gameObject.tag == "Enemy")
            name = enemyNames[Random.Range(0, 20)];
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

    void OnStateChangedNotify(string name, float value)
    {
        var text = Instantiate(expText, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        text.transform.SetParent(GameObject.FindGameObjectWithTag("PlayerBar").transform);

        if (name == "exp")
        {

            text.GetComponent<Text>().text = value + " " + name;
            text.transform.position = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
            text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);

            if (value >= this.maxExp)
            {
                this._level++;
                this.exp = 0;
                UpdateStats();
            }
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
        if (name == "mana" )
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

        Respawn();
        //Destroy(this.gameObject);
    }

    public override void Respawn()
    {

    }

}

