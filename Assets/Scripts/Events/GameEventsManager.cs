using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager Instance { get; private set; }

    public PlayerEvents playerEvents;
    private void Awake()
    {
        Debug.Log("GameEventsManager Awake");
        if (Instance != null)
        {
            Debug.Log("Found more than one Game Events Manager in the scene. Destroying the newest one");
            Destroy(this.gameObject);
            return;
        }

        // initialize all events
        playerEvents = new PlayerEvents();
        Instance = this;
    }
}