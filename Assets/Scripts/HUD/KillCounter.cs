using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    private Text text;
    private int killCount = 0;
    
    void Start()
    {
        text = GetComponent<Text>();
        GlobalEventManager.OnEnemyKilled.AddListener(UpdateKillCounter);
    }

    void UpdateKillCounter()
    {
        killCount++;
        text.text = killCount.ToString();
    }
}
