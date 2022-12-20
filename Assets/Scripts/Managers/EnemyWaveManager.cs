using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    private int wavesCount;

    private void Start()
    {
        wavesCount = transform.childCount;
        transform.GetChild(0).gameObject.SetActive(true);
        GlobalEventManager.OnWaveEliminated.AddListener(UpdateWaves);
    }

    void UpdateWaves()
    {
        wavesCount--;
        if (wavesCount < 1) GlobalEventManager.SendLevelComplete();
        else transform.GetChild(1).gameObject.SetActive(true);
    }
}
