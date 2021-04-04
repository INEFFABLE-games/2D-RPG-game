using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class EnemyStats : AbstractCharacter
{

    List<string> enemyNames;

    public GameObject effect;
    public Sprite dead;
    public Vector3 respawnPoint;
    public uint startLevel;
    public GameObject expText;

    public GameObject moneyDrop;

    void Start()
    {
        UpdateStats();
        Health = MaxHealth;
        GenNotify += OnStateChangedNotify;
        DiedNotify += OnDied;
        StartCoroutine(RegenerationHandler());
        level = startLevel;

        level += (uint)Random.Range(1, 20);

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

    void Update()
    {

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

        Destroy(this.gameObject);
    }

    public override void Respawn()
    {
        Wait(10.0f);
        GameObject newenemy = Instantiate(this.gameObject, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5)), transform.rotation);

        Debug.Log("respawned");
    }

}

