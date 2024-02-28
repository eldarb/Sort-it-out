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
    [SerializeField] float fluctuationRate = .5f;
    bool increasing;
    PlayerManager playerManager;

    void Start()
    {
        slider = GetComponent<Slider>();
        startTime = 0;
        increasing = true;
        slider.maxValue = maxPower;
        playerManager = GetComponentInParent<PlayerManager>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // reset
    //    if (Time.time - startTime > fluctuationTime) {startTime = Time.time; increasing = !increasing; }
    //    // increasing
    //    else if(increasing)
    //    {
    //        slider.value = (Time.time - startTime) / (fluctuationTime) * slider.maxValue;
    //        //Debug.Log("increasing" + slider.value);
    //    }
    //    // decreasing
    //    else if (!increasing)
    //    {
    //        slider.value = slider.maxValue - (Time.time-startTime)/(fluctuationTime) * slider.maxValue;
    //        //Debug.Log("decreasing" + slider.value);
    //    }
        
    //}

    public void AdjustPower()
    {
        float power = playerManager.playerInputManager.power;
        Debug.Log("Power: " + power);
        if(power == 0) { return; }
        else if(power > 0 && slider.value < slider.maxValue)
        {
            slider.value += 1f * fluctuationRate;
        }
        else if(power < 0 && slider.value > 0)
        {
            slider.value -= 1f * fluctuationRate; 
        }
        //Debug.Log("slider value: " + slider.value);
    }

}
