using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    private static GameObject player;
    
    public static UnityEvent OnEnemyKilled = new UnityEvent();
    public static readonly UnityEvent <GameObject> OnPlayerSpawned = new UnityEvent<GameObject>();

    public static UnityEvent OnLevelComplete = new UnityEvent();

    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }

    public static void SendPlayerSpawned(GameObject player)
    {
        OnPlayerSpawned.Invoke(player);
    }

    public static void SetPlayer(GameObject player)
    {
        GlobalEventManager.player = player;
    }

    public static GameObject GetPlayer()
    {
        return GlobalEventManager.player;
    }

    public static void SendLevelComplete()
    {
        OnLevelComplete.Invoke();
    }
}
