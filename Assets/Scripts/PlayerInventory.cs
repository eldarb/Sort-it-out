using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    private Stack<GameObject> Inventory;
    /// <summary>
    /// private TextMeshPro variable to hold the vaccum item text.
    /// </summary>
    private TextMeshPro m_TextMeshPro;
    public int size = 5;

    private void Awake()
    {
        Inventory = new Stack<GameObject>();
        //Grabbing the TextMeshPro component from the ItemCountText GameObject
        m_TextMeshPro = GameObject.Find("ItemCountText").GetComponent<TextMeshPro>();
    }

    //private void Start()
    //{
    //    GameEventsManager.Instance.playerEvents.onCollect += OnCollect;
    //    GameEventsManager.Instance.playerEvents.onRelease += OnRelease;
    //}

    //void OnEnable()
    //{
    //    if(GameEventsManager.Instance == null) { return; }
    //    GameEventsManager.Instance.playerEvents.onCollect += OnCollect;
    //    GameEventsManager.Instance.playerEvents.onRelease += OnRelease;
    //}

    //void OnDisable()
    //{
    //    GameEventsManager.Instance.playerEvents.onCollect -= OnCollect;
    //    GameEventsManager.Instance.playerEvents.onRelease -= OnRelease;
    //}

    public void OnCollect(GameObject obj)
    {
        if (Inventory.Count < size)
        {
            Inventory.Push(obj);
            Debug.Log("Item collected");
            //Updates Vacuum text.
            m_TextMeshPro.text = Inventory.Count + "/" + size;
        }
    }

    public GameObject OnRelease()
    {
        if (Inventory.Count > 0) 
        {
            Debug.Log("Item released");
            //Updates vacuum text.
            m_TextMeshPro.text = (Inventory.Count - 1) + "/" + size;
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
