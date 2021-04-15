using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Settlement : AbstractCharacter
{

    List<string> enemyNames;

    public GameObject effect;
    public Sprite dead;
    public GameObject expText;
    [SerializeField]GameObject template;

    public GameObject moneyDrop;

    void Start()
    {
        multiArmorA = 1;
        multiMagicDamageA = 1;
        multiSpeedA = 1;
        multiWeaponDamageA = 1;
        tag = "NPC";
        level += (uint)Random.Range(1, 10);
        UpdateStats();
        Health = MaxHealth;
        GenNotify += OnStateChangedNotify;
        DiedNotify += OnDied;
        StartCoroutine(RegenerationHandler());



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
        name = enemyNames[Random.Range(0, 20)];
    }

    void OnStateChangedNotify(string name, float value, float fval)
    {
        var text = Instantiate(expText, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        text.transform.SetParent(GameObject.FindGameObjectWithTag("PlayerBar").transform);

        if (name == "health")
        {

            if (value >= 0)
            {
                text.GetComponent<Text>().text = +value + "hp";
                text.transform.position = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                text.GetComponent<Text>().color = Color.green;

            }
            else if (value < 0)
            {
                text.GetComponent<Text>().text = +value + "hp";
                text.transform.position = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                text.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                text.GetComponent<Text>().color = Color.red;

            }
        }

    }

    void OnDied(string message)
    {
        Debug.Log(message);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        Instantiate(effect, transform.position, transform.rotation);

        var plrStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        plrStats.exp += 100 * (10 + this.level - plrStats.level) / (10 + plrStats.level);

        Respawn();

        if (Random.Range(1, 5) == 1)
        {
            GameObject money = Instantiate(moneyDrop, transform.position, transform.rotation);
            money.GetComponent<AbstractItem>().Amount = (uint)Random.Range(1, Mathf.Abs(Mathf.Sqrt(level) * 10));
        }

        GameObject.Destroy(gameObject);

    }

    public override void Respawn()
    {
        GameObject.FindGameObjectWithTag("RespawnManager").GetComponent<TimedRespawn>().Respawn(30f,respawnPosition,"Settlement");
    }

}

