using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;


public class Player : MonoBehaviour, IHitable
{
    public static Player instance { get; private set; }
    
    // Характеристики
    // [Header("Характеристики")]
    [field: SerializeField] public int maxHealth { get; private set; } = 500;
    [field: SerializeField] public int health { get; private set; }


    // Ведение боя
    [Header("Ведение боя")]
    [SerializeField] private float parryWindowSize = 0.2f;
    [SerializeField] private float parryCooldown = 0.8f;
    [SerializeField] private bool isParryWindow = false;
    [SerializeField] private bool isParryReady = true;

    // Эффекты
    [Header("Эффекты")]
    [SerializeField] private AudioSource DeathSound;

    private void Awake()
    {
        if (!Player.instance) instance = this;
        health = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2) && isParryReady) {
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
            
            if (DeathSound) DeathSound.Play();
            CameraShaker.Instance.ShakeOnce(4.0f, 4.0f, 0.1f, 0.1f);
            GlobalEventManager.SendPlayerRecievedDamage();
        }
    }

    public void TakeHealing(int inputHealing)
    {
        // health += inputHealing;
        health = Mathf.Clamp(health + inputHealing, 0, maxHealth);
        GlobalEventManager.SendPlayerHealed();
    }
    
    public void Die()
    {
        GlobalEventManager.SendPlayerKilled();
        gameObject.SetActive(false);
    }
}

