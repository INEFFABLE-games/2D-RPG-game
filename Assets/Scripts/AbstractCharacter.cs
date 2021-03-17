using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AbstractCharacter : MonoBehaviour
{

    protected IEnumerator RegenerationHandler()
    {
        while (true)
        {
            if (!isAttacked)
                Health += 10;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator Wait(int waitTime)
    {
        yield
        return new WaitForSeconds(waitTime);
    }

    public delegate void OnStateChanged(string name, float value);
    public event OnStateChanged StateNotify;

    public delegate void OnPlayerDied(string mes);
    public event OnPlayerDied DiedNotify;

    public bool _isAttacked;
    public bool isAttacked
    {
        get { return _isAttacked; }
        set { _isAttacked = value; }
    }

    public uint _level;
    public uint level{get{return _level;}
        set
        {
        _level = value;

        }
    }
    public float _exp;
    public float exp{get{return _exp;}set{if(value > 0){_exp = value;StateNotify?.Invoke("exp",value);}}}
    
    public float _maxExp;
    public float maxExp{get{return _maxExp;}set{if(value > 0){_maxExp = value;}}}

    public float _magicLevel;
    public float magicLevel{get{return _magicLevel;}set{if(value > 0) _magicLevel = value;}}

    public float _weaponDamage;
    public float weaponDamage{get{return _weaponDamage;}set{if(value > 0)_weaponDamage = value;}}


    
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
    public float maxMana{get{return _maxMana;}set{if(value > 0) _maxMana = value;}}
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
                _mana = value; StateNotify?.Invoke("Mana", _mana);
            }
            else if (value <= 0)
            {
                _mana = 0; StateNotify?.Invoke("Mana", _mana);
            }
            else if (value >= MaxHealth)
            {
                _mana = maxMana; StateNotify?.Invoke("Mana", _mana);
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
            if (value > 0) _MaxHealth = value; StateNotify?.Invoke("MaxHealth", value);
        }
    }

    public void TakeDamage(float dmg)
    {
        Health -= dmg * 100 * Time.deltaTime;
    }

    public void Heal(float value)
    {
        Health += value * 100 * Time.deltaTime;
    }

    public void AddMana(float value)
    {
        mana += value * 100 * Time.deltaTime;
    }

    public void UpdateStats()
    {
                maxExp = Mathf.Exp(level/3)*level;
                Debug.Log("maxExp: " + maxExp);

                magicLevel = Mathf.Exp(level/10)*level;
                weaponDamage = Mathf.Exp(level/10)*level;

                MaxHealth = Mathf.Exp(level/5)*level;
    }

}
