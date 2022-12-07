using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private Text text;
    private int killCount = 0;
    private Animator animator;
    private static readonly int EnemyKilled = Animator.StringToHash("EnemyKilled");
    
    void Start()
    {
        animator = GetComponent<Animator>();
        GlobalEventManager.OnEnemyKilled.AddListener(UpdateKillCounter);
    }

    void UpdateKillCounter()
    {
        killCount++;
        text.text = killCount.ToString();
        animator.SetTrigger(EnemyKilled);
    }
}
