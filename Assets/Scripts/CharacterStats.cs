using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CharacterStats : AbstractCharacter
{
    public GameObject effect;
    public Sprite dead;
    public Vector3 Resp;
    public GameObject enemyPrefab;

    public IEnumerator Wait(float waitTime)
    {
        yield
        return new WaitForSeconds(waitTime);
    }
    
    void Start()
    {
        UpdateStats();
        Health = MaxHealth;
        StateNotify += OnStateChangedNotify;
        DiedNotify += OnDied;
        StartCoroutine(RegenerationHandler());
        Resp = transform.position;
    }

    // Update is called once per frame
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
        if(Input.GetKeyDown(KeyCode.L))
        {
            AddLevel();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(100);
        }


    }

    void OnStateChangedNotify(string name, float value)
    {

        if(name == "exp" && value >= maxExp && this.gameObject.tag == "Player")
        {
                exp = 0;
                _level++;
                UpdateStats();
        }

    }

    void AddLevel()
    {
        level++;
        UpdateStats();
    }

    void AddExp(float val)
    {
        if(this.gameObject.tag == "Player")
        exp += val;
    }

    void OnDied(string message)
    {
        Debug.Log(message);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    
}

