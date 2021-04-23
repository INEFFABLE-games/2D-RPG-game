using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayAndNightSystem : MonoBehaviour
{
    [SerializeField] private Gradient lightColor;
    [SerializeField] private GameObject light;

    private int _days;
    public int Days{get{return _days;}set{_days = value;}}
    private float _time = 50;
    private bool canChangeDay = true;
    public delegate void OnDayChanged();

    public OnDayChanged DayChanged;

    private void Update() {
        if(_time > 500)
        {
            _time = 0;
        }
        
        if((int)_time == 250 && canChangeDay)
        {
            canChangeDay = false;
            DayChanged();
            Days++;
        }

        if((int) _time == 255)
        {
            canChangeDay = true;
        }

        _time -= Time.deltaTime;
        light.GetComponent<Light2D>().color = lightColor.Evaluate(_time * 0.002f);
    }


}
