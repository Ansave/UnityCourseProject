using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Wave : MonoBehaviour
{
    private void Update()
    {   
        CheckWave();
    }

    private void CheckWave()
    {
        if (transform.childCount < 1) Eliminate();
    }

    void Eliminate()
    {
        GlobalEventManager.SendWaveElininated();
        Destroy(gameObject);
    }
}
