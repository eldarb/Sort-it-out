using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public event Action onSprintStart;
    public void SprintStart()
    {
        Debug.Log(onSprintStart);
        if(onSprintStart != null)
        {
            onSprintStart();
        }
    }
    public event Action onSprintEnd;
    public void SprintEnd()
    {
        if (onSprintEnd != null)
        {
            onSprintEnd();
        }
    }
    public event Action onCrouchStart;
    public void CrouchStart()
    {
        if (onCrouchStart != null)
        {
            onCrouchStart();
        }
    }
    public event Action onCrouchEnd;
    public void CrouchEnd()
    {
        if (onCrouchEnd != null)
        {
            onCrouchEnd();
        }
    }

    public event Action onFire;
    public void Fire()
    {
        if (onFire != null)
        {
            onFire();
        }
    }
    //public event Action onPickUp;
    //public void PickUp()
    //{
    //    if (onPickUp != null)
    //    {
    //        onPickUp();
    //    }
    //}

    //public event Action onThrow;
    //public void Throw()
    //{
    //    if (onThrow != null)
    //    {
    //        onThrow();
    //    }
    //}

    //public event Action<GameObject> onCollect;
    //public void Collect(GameObject obj)
    //{
    //    if (onCollect != null)
    //    {
    //        onCollect(obj);
    //    }
    //}

    //public event Func<GameObject> onRelease;
    //public GameObject Release()
    //{
    //    if (onRelease != null)
    //    {
    //        return onRelease();
    //    }
    //    return null;
    //}
}
