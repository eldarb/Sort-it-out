using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingScreenScript : MonoBehaviour
{

    public string[] m_FactsArray;

    private TextMeshPro m_FactText;

    private float m_currentFactFloat;

    private float m_FactTimer = 0;

    // private bool m_IsFactDone = false;

    void Awake()
    {
        m_FactText = GameObject.Find("FactText").GetComponent<TextMeshPro>();
        // m_currentFactFloat = Random.Range(0f,m_FactsArray.Length);
    }

    void start()
    {
        Debug.Log(m_FactText.text);
        // m_FactText.text = "Hello";
    }

    // Update is called once per frame
    void Update()
    {
        // if(m_FactTimer <= 10)
        // {
        //     m_FactTimer += Time.deltaTime;
        // }
        // else 
        // {
        //     m_FactTimer = 0;
        //     float m_NextFactFloat = Random.Range(0f,m_FactsArray.Length);
        //     while(m_NextFactFloat == m_currentFactFloat)
        //     {
        //         m_NextFactFloat = Random.Range(0f,m_FactsArray.Length);
        //     }
        //     m_FactText.text = m_FactsArray[(int) m_currentFactFloat];
        //     m_currentFactFloat = m_NextFactFloat;
        // }
    }
}
