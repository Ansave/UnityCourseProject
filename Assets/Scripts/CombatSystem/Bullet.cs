using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float impactExplosionForse = 500f;
    [SerializeField] private float impactExplosionPad = 5f;
    [SerializeField] private float liveTime = 1f;
    private Rigidbody myRigidbody;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, liveTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        myRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHitable enemy)) {
            enemy.TakeDamage(damage, Player.instance.gameObject);
        }
        
        if (other.TryGetComponent(out Rigidbody enemyRigitbody)) {
            var explosionPosition = transform.position - transform.forward * impactExplosionPad;
            enemyRigitbody.AddExplosionForce(impactExplosionForse, explosionPosition, 20);
        }
        
        Destroy(gameObject);
    }
}
