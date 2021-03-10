using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerStats : MonoBehaviour
{

    IEnumerator Wait(int waitTime)
    {
        yield
        return new WaitForSeconds(waitTime);
    }

    private IEnumerator RegenerationHandler()
    {
        while (true)
        {
            if (!isAttacked)
                Health += 10;
            yield return new WaitForSeconds(1);
        }
    }

    // Start is called before the first frame update
    public delegate void OnStateChanged(string name, float value);
    public event OnStateChanged StateNotify;

    public bool _isAttacked;
    public bool isAttacked
    {
        get { return _isAttacked; }
        set { _isAttacked = value; }
    }


    public delegate void OnPlayerDied(string mes);
    public event OnPlayerDied DiedNotify;

    public float _MaxHealth;
    public float _Health;
    public float ChangeHpValue;


    //DEbug values

    //DEbug values

    public float MaxHealth
    {
        get
        {
            return _MaxHealth;
        }
        set
        {
            if (value > 0) _MaxHealth = value; StateNotify?.Invoke("MaxHealth", value);
        }
    }

    public float Health
    {
        get
        {
            return _Health;
        }
        set
        {
            if (value > 0 && value < MaxHealth)
            {
                _Health = value; StateNotify?.Invoke("Health", _Health);
            }
            else if (value <= 0)
            {
                _Health = 0; DiedNotify?.Invoke("Player died..."); StateNotify?.Invoke("Health", _Health);
            }
            else if (value >= MaxHealth)
            {
                _Health = MaxHealth; StateNotify?.Invoke("Health", _Health);
            }
        }
    }

    void Start()
    {
        Health = MaxHealth;
        StateNotify += OnStateChangedNotify;
        DiedNotify += OnDied;
        StartCoroutine(RegenerationHandler());

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(ChangeHpValue);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            HealPlayer(ChangeHpValue);
        }



    }

    void OnStateChangedNotify(string name, float value)
    {
        //Debug.Log("State [" + name + "]: " + value);
    }

    void OnDied(string message)
    {
        Debug.Log(message);
    }

    public void TakeDamage(float dmg)
    {
        Health -= dmg * 100 * Time.deltaTime;
    }

    void HpRegen(string name, float value)
    {
        if (!isAttacked && Health < MaxHealth && name == "Health")
        {
            //Wait(1);
            Thread.Sleep(1000);
            Health += MaxHealth / 10;
        }

    }

    void HealPlayer(float hp)
    {
        Health += hp * 100 * Time.deltaTime;
    }

}

