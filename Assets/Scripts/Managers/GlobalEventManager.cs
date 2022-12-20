using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static readonly UnityEvent OnPlayerKilled = new UnityEvent();
    public static readonly UnityEvent OnEnemyKilled = new UnityEvent();
    public static readonly UnityEvent OnPlayerRecievedDamage = new UnityEvent();
    public static readonly UnityEvent OnPlayerHealed = new UnityEvent();
    public static readonly UnityEvent OnEnemyRecievedDamage = new UnityEvent();

    public static readonly UnityEvent OnLevelComplete = new UnityEvent();
    

    public static void SendPlayerKilled()
    {
        OnPlayerKilled.Invoke();
    }
    
    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }

    public static void SendPlayerRecievedDamage()
    {
        OnPlayerRecievedDamage.Invoke();
    }

    public static void SendPlayerHealed()
    {
        OnPlayerHealed.Invoke();
    }
    
    public static void SendEnemyRecievedDamage()
    {
        OnEnemyRecievedDamage.Invoke();
    }

    public static void SendLevelComplete()
    {
        OnLevelComplete.Invoke();
    }
}
