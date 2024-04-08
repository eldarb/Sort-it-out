using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    private Image img;

    private float currentAlpha = 1f;

    private float desiredAlpha = 0f;

    private bool isFadeInDone = false;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        img = GameObject.Find("Image").GetComponent<Image>();
        // img.color = new Color(255,255,255,100);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFadeInDone)
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, 0.25f * Time.deltaTime);
            // currentAlpha = Mathf.Lerp(currentAlpha, desiredAlpha, 0.25f * Time.deltaTime);
            // Debug.Log("currentAlpha: " + currentAlpha);
            // Debug.Log("desiredAlpha: " + desiredAlpha);
            img.color = new Color(img.color.r, img.color.g , img.color.b , currentAlpha);
            if(currentAlpha == desiredAlpha)
            {
                isFadeInDone = true;
            }
        }
        else if (isFadeInDone && timer < 10)
        {
            timer += Time.deltaTime;
            desiredAlpha = 1;
        }
        else if (isFadeInDone && timer > 10)
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, 0.25f * Time.deltaTime);
            // currentAlpha = Mathf.Lerp(currentAlpha, desiredAlpha, 0.25f * Time.deltaTime);
            // Debug.Log(currentAlpha);
            img.color = new Color(img.color.r, img.color.g , img.color.b , currentAlpha);
        }
    }
}
