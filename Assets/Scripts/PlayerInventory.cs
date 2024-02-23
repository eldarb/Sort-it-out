using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Stack<GameObject> Inventory;
    public int size = 4;

    private void Awake()
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
        if (Inventory.Count < size)
        {
            Inventory.Push(obj);
            Debug.Log("Item collected");
        }
    }

    public GameObject OnRelease()
    {
        if (Inventory.Count > 0) 
        {
            Debug.Log("Item released");
            return Inventory.Pop();
        }
        return null;
        
    }

    public bool CheckFull()
    {
        if (Inventory.Count < size) return false;
        return true;
    }
}
