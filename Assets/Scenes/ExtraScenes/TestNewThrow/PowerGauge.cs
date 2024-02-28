using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerGauge : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider { private set; get; }
    float startTime;
    [SerializeField] float maxPower = 1; 
    [SerializeField] float fluctuationTime = .5f;
    bool increasing;

    void Start()
    {
        slider = GetComponent<Slider>();
        startTime = 0;
        increasing = true;
        slider.maxValue = maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        // reset
        if (Time.time - startTime > fluctuationTime) {startTime = Time.time; increasing = !increasing; }
        // increasing
        else if(increasing)
        {
            slider.value = (Time.time - startTime) / (fluctuationTime) * slider.maxValue;
            //Debug.Log("increasing" + slider.value);
        }
        // decreasing
        else if (!increasing)
        {
            slider.value = slider.maxValue - (Time.time-startTime)/(fluctuationTime) * slider.maxValue;
            //Debug.Log("decreasing" + slider.value);
        }
        
    }
}
