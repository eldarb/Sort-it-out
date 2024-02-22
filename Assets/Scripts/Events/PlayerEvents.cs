using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{
    public event Action onSprintStart;
    public void SprintStart()
    {
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
    public event Action onPickUp;
    public void PickUp()
    {
        if (onPickUp != null)
        {
            onPickUp();
        }
    }

    public event Action onThrow;
    public void Throw()
    {
        if (onThrow != null)
        {
            onThrow();
        }
    }
}
