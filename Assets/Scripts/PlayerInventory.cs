using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Stack<GameObject> Inventory;
    public int size = 4;

    void Awake()
    {
        Inventory = new Stack<GameObject>();
    }

    void OnEnable()
    {
        GameEventsManager.Instance.playerEvents.onCollect += OnCollect;
        GameEventsManager.Instance.playerEvents.onRelease += OnRelease;
    }

    void OnDisable()
    {
        GameEventsManager.Instance.playerEvents.onCollect -= OnCollect;
        GameEventsManager.Instance.playerEvents.onRelease -= OnRelease;
    }

    public void OnCollect(GameObject obj)
    {
        if (Inventory.Count < size) Inventory.Push(obj);
    }

    public GameObject OnRelease()
    {
        if (Inventory.Count == 0) return null;
        return Inventory.Pop();
    }
    
}
