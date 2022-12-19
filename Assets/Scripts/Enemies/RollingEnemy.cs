using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;

public class RollingEnemy : MonoBehaviour, IHitable, IParryble
{
    // Характеристики
    private const int maxHealth = 100;
    private int health = maxHealth;
    private int damage = 25;
    
    // Физика
    private Rigidbody myRigidbody;
    [SerializeField] private AnimationCurve forseCurve;
    [SerializeField] private float forseScale = 3f;
    
    // Цель
    public GameObject target = null;
    
    // Анимация
    [SerializeField] private float rollAngleScale = 0.015f;
    [SerializeField] private float rollAngleMax = 45f;

    // Эффекты
    public AudioSource hitSound;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        target = GlobalEventManager.GetPlayer();
        GlobalEventManager.OnPlayerSpawned.AddListener(player => target = player);
    }
    
    void Update()
    {
        Roll();
    }

    private void FixedUpdate()
    {
        if (target) Move();
    }

    private void Move() // Непосредственно движение
    {
        // Ориентация на цель
        transform.LookAt(target.transform.position);
        
        // Воздействие силы по направлению к цели
        var toTargetDirection = target.transform.position - transform.position;
        var toTargetForse = toTargetDirection.normalized * forseCurve.Evaluate(toTargetDirection.magnitude) * forseScale;
        myRigidbody.AddForce(toTargetForse, ForceMode.Force);
    }

    private void Roll() // Крен в сторону цели
    {
        // Крен через тангенсальное ускорение
        float rollAngle = Vector3.SignedAngle(transform.forward, myRigidbody.velocity.normalized, transform.up);
        rollAngle = Mathf.Sign(rollAngle) * Mathf.PingPong(rollAngle, 90);
        rollAngle *= Mathf.Clamp(myRigidbody.velocity.magnitude * rollAngleScale, 0, 1);
        rollAngle = Mathf.Clamp(rollAngle, -rollAngleMax, rollAngleMax);
        
        transform.localEulerAngles = new Vector3(
            transform.localEulerAngles.x,
            transform.localEulerAngles.y,
            rollAngle);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        hitSound.Play();

        if (other.gameObject.TryGetComponent(out PlayerCombat player)) {
            player.TakeDamage(damage, gameObject);
        }
    }

    public void TakeDamage(int inputDamage, GameObject attacker)
    {
        health -= inputDamage;
        if (health < 1) Die();
        
        GlobalEventManager.SendEnemyRecievedDamage();
    }

    public void Parried(GameObject initiator)
    {
        myRigidbody.AddExplosionForce(2500, initiator.transform.position, 10);
    }

    public void Die()
    {
        GlobalEventManager.SendEnemyKilled();
        Destroy(gameObject);
    }
}
