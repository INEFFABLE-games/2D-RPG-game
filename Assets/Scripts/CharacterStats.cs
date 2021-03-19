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
    public Vector3 respawnPoint;
    public uint startLevel;
    public GameObject expText;

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
        level = startLevel;

        if(this.gameObject.tag == "Enemy")
        level += (uint)Random.Range(1,20);

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
        if(this.gameObject.tag == "Enemy")
        name = enemyNames[Random.Range(0,20)];
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

        if(name == "exp" && this.gameObject.tag == "Player")
        {

            var exptext = Instantiate(expText,transform.position,transform.rotation);
            //exptext.SetParent(this.gameObject.GetComponent<NameBar>());
            
            if(value >= maxExp)
            {
                _level++;
                exp = 0;
                UpdateStats();
            }
        }

    }

    void AddLevel()
    {
        if(this.gameObject.tag == "Player")
        {
        level++;
        UpdateStats();
        }
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
        if(this.gameObject.tag == "Enemy")
        {
            var plrStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
            plrStats.exp += 100 * (10 + level - plrStats.level)/(10 + plrStats.level);
            Respawn();
        }
        Destroy(this.gameObject);
    }

    void Respawn()
    {
        Wait(10.0f);
        GameObject newenemy = Instantiate(this.gameObject,new Vector3(Random.Range(-5,5),Random.Range(-5,5)),transform.rotation);
        
        Debug.Log("respawned");
    }

}

