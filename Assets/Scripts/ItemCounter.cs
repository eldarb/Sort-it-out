using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to keep count of the items that get deleted from correctly placing the 
/// recyclable in the according bins.
/// </summary>
public class ItemCounter : MonoBehaviour
{
    /// <summary>
    /// int variable to hold the number of items that were deleted from the playfield.
    /// </summary>
    private int m_NumOfItems;

    /// <summary>
    /// On awake, sets m_NumOfItems to zero.
    /// </summary>
    void Awake()
    {
        m_NumOfItems = 0;
    }

    /// <summary>
    /// Add the numbers of items to m_NumOfItems.
    /// </summary>
    /// <param name="items"> int to the added to m_NumOfItems. Should always be 1.</param>
    public void addItem(int items)
    {
        m_NumOfItems += items;
    }

    /// <summary>
    /// Returns the number of m_NumOfItems.
    /// </summary>
    /// <returns> returns an int of m_NumOfItems</returns>
    public int getItem()
    {
        return m_NumOfItems;
    }
}
