using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    int waypointIndex = 1;
    [SerializeField] Transform[] waypoints;
    [SerializeField] float Speed = 2.0f;
    [SerializeField] float platformWaitTime = 3.0f;

    [SerializeField] GameObject platformObject;
    bool isChangingDirection;

    private void FixedUpdate()
    {
        //Moving to the desired position
        if (waypointIndex < waypoints.Length)
        {
            platformObject.transform.position = Vector3.MoveTowards(platformObject.transform.position, waypoints[waypointIndex].transform.position, Speed * Time.fixedDeltaTime);
            //Changing the direciton of movement
            if (platformObject.transform.position == waypoints[waypointIndex].transform.position)
            {
                isChangingDirection = !isChangingDirection;
                StartCoroutine(wait());
            }
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(platformWaitTime);
        if(!isChangingDirection)
        {
            waypointIndex = 1;
        }
        else
        {
            waypointIndex = 0;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(platformObject.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}


