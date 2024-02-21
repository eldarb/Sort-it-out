using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to change the ControlPanel Size with respects to the Canvas.
/// </summary>
public class ControlsTransformScript : MonoBehaviour
{
    /// <summary>
    /// Private RectTransform variable to hold the Canvas.
    /// </summary>
    private RectTransform m_Canvas;

    /// <summary>
    /// Private const float to hold Width difference of Canvas with ControlPanel.
    /// </summary>
    private const float m_WidthDiff = 6f;

    /// <summary>
    /// Private const float to hold Height multiplier of Canvas with ControlPanel.
    /// </summary>
    private const float m_MultiplierHeight = 0.8f;

    /// <summary>
    /// Start is called before the first frame update.
    /// Sets m_Canvas variable.
    /// </summary>
    void Start()
    {
        m_Canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// If the Canvas size change, change the size of the ControlPanel.
    /// </summary>
    void Update()
    {
        if(m_Canvas.hasChanged)
        {
            RectTransform m_ControlsPanel = GetComponent<RectTransform>();
            if(m_Canvas.rect.width > m_WidthDiff)
            {
                m_ControlsPanel.sizeDelta = new Vector2(m_Canvas.sizeDelta.x - m_WidthDiff, m_Canvas.sizeDelta.y * m_MultiplierHeight);
            }
        }
    }
}