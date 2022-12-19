using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, IHitable
{
    // Характеристики
    [Header("Характеристики")]
    [SerializeField] public int maxHealth = 500;
    [SerializeField] public int health;

    // Ведение боя
    [Header("Ведение боя")]
    [SerializeField] private float parryWindowSize = 0.2f;
    [SerializeField] private float parryCooldown = 0.8f;
    [SerializeField] private bool isParryWindow = false;
    [SerializeField] private bool isParryReady = true;

    // Эффекты
    [Header("Эффекты")]
    [SerializeField] private AudioSource DeathSound = new AudioSource();

    private void Awake()
    {
        GlobalEventManager.SetPlayer(gameObject);
        GlobalEventManager.SendPlayerSpawned(gameObject);
    }

    void Start()
    {
        health = maxHealth;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && isParryReady) {
            StartCoroutine(ActivateParryWindow());
            StartCoroutine(ActivateParryCooldown());
        }
    }

    IEnumerator ActivateParryWindow()
    {
        isParryWindow = true;
        yield return new WaitForSeconds(parryWindowSize);
        isParryWindow = false;
    }    
    
    IEnumerator ActivateParryCooldown()
    {
        isParryReady = false;
        yield return new WaitForSeconds(parryCooldown);
        isParryReady = true;
    }
    
    private void ResetParry()
    {
        StopCoroutine(ActivateParryWindow());
        StopCoroutine(ActivateParryCooldown());
        isParryWindow = false;
        isParryReady = true;
    }

    private void Parry(GameObject attacker)
    {
        ResetParry();

        if(attacker.TryGetComponent(out IParryble parrybleAttacker))
        {
            parrybleAttacker.Parried(gameObject);
        }
    }

    public void TakeDamage(int inputDamage, GameObject attacker)
    {
        if (isParryWindow) {
            Parry(attacker);
        }
        else {
            health -= inputDamage;
            if (health < 1) Die();
            
            DeathSound.Play();
            GlobalEventManager.SendPlayerRecievedDamage();
        }
    }

    public void TakeHealing(int inputHealing)
    {
        health += inputHealing;
        GlobalEventManager.SendPlayerHealed();
    }
    
    public void Die()
    {
        GlobalEventManager.SendPlayerKilled();
        gameObject.SetActive(false);
    }
}

