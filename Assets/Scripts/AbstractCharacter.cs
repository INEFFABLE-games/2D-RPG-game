using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class AbstractCharacter : MonoBehaviour
{

    protected IEnumerator RegenerationHandler()
    {
        while (true)
        {
            if (!isAttacked && Health < MaxHealth)
                Health += 10;
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator Wait(float waitTime)
    {
        yield
        return new WaitForSeconds(waitTime);
    }

    public delegate void OnGeneralStateChanged(string name, float value,float fval);
    public event OnGeneralStateChanged GenNotify;

    public string _name;
    public string Name { get { return _name; } set { _name = value; } }

    public delegate void OnPlayerDied(string mes);
    public event OnPlayerDied DiedNotify;

    public bool _isAttacked;
    public bool isAttacked
    {
        get { return _isAttacked; }
        set { _isAttacked = value; }
    }

    public uint _level;
    public uint level
    {
        get { return _level; }
        set
        {
            _level = value;

        }
    }
    public float _exp;
    public float exp
    {
        get { return _exp; }
        set
        {
            if (value >= 0)
            {
                if (value > _maxExp)
                {
                    GenNotify?.Invoke("exp", value - _exp,value);
                    _exp = value - _maxExp;
                    level++;
                    UpdateStats();
                    
                }
                else if (value < _maxExp)
                {
                    GenNotify?.Invoke("exp", value - _exp,value);
                    _exp = value;
                }

            }
        }
    }

    public float _maxExp;
    public float maxExp { get { return _maxExp; } set { if (value >= 0) { _maxExp = value; } } }

    public float _magicLevel;
    public float magicLevel { get { return _magicLevel; } set { if (value >= 0) _magicLevel = value; } }

    public float _weaponDamage;
    public float weaponDamage { get { return _weaponDamage; } set { if (value >= 0) _weaponDamage = value; } }


    public float _MaxHealth;
    public float _Health;
    public float _maxMana;
    public float _mana;

    public float ChangeValue;

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
                if (value > _Health)
                {
                    GenNotify?.Invoke("health", value - _Health,value);
                }
                else if (value < _Health)
                    GenNotify?.Invoke("health", value - _Health,value);


                _Health = value;
            }
            else if (value <= 0)
            {
                if (value > _Health)
                {
                    GenNotify?.Invoke("health", value - _Health,value);
                    
                }
                else if (value < _Health)
                {
                    GenNotify?.Invoke("health", value - _Health,value);
                }   


                _Health = 0; DiedNotify?.Invoke("Player died...");
            }
            else if (value >= MaxHealth)
            {
                if (value > _Health)
                {
                    GenNotify?.Invoke("health", value - _Health,value);

                }
                else if (value < _Health)
                {
                    GenNotify?.Invoke("health", value - _Health, value);
                }

                    
                _Health = MaxHealth;
            }
        }
    }
    public float maxMana { get { return _maxMana; } set { if (value > 0) _maxMana = value; } }
    public float mana
    {
        get
        {
            return _mana;
        }
        set
        {
            if (value > 0 && value < maxMana)
            {
                _mana = value; 
                GenNotify?.Invoke("mana", value - _mana, value);

            }
            else if (value <= 0)
            {
                _mana = 0; 
                GenNotify?.Invoke("mana", value - _mana, value);

            }
            else if (value >= maxMana)
            {
                _mana = maxMana; 
                GenNotify?.Invoke("mana", value - _mana, value);

            }
        }
    }
    public float MaxHealth
    {
        get
        {
            return _MaxHealth;
        }
        set
        {
            if (value > 0) _MaxHealth = value; 
            GenNotify?.Invoke("MaxHealth",value - _MaxHealth,value);
        }
    }

    public void TakeDamage(float dmg)
    {
        Health -= dmg;
    }

    public void Heal(float value)
    {
        Health += value;
    }

    public void AddMana(float value)
    {
        mana += value;
    }

    public void UpdateStats()
    {
        maxExp = 1000 + 100 * level;
        Debug.Log("maxExp: " + maxExp);

        magicLevel = 25 * level;
        weaponDamage = 25 * level;

        MaxHealth = 100 + 75 * level;
    }

    public virtual void Respawn()
    {

    }

}
