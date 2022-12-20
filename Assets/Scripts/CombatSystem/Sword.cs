using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    [SerializeField] private float attackRadius = 20f;
    [SerializeField] private float attackExplosionForse = 20f;

    
    private Animator weaponAnimator;
    private static readonly int PrimaryWeaponAttack = Animator.StringToHash("PrimaryWeaponAttack");
    
    // Start is called before the first frame update
    void Start()
    {
        weaponAnimator = gameObject.GetComponent<Animator>();
    }
    
    protected override void Attack()
    {
        weaponAnimator.SetTrigger(PrimaryWeaponAttack);
        StartCoroutine(AttackCooldown());
        
        Collider[] hittedEnemies = Physics.OverlapSphere(transform.position, attackRadius, enemyLayerMask);

        foreach (var enemy in hittedEnemies) {
            
            if (enemy.TryGetComponent(out Rigidbody enemyRigitbody)) {
                enemyRigitbody.AddExplosionForce(attackExplosionForse, transform.position, attackRadius);
            }

            if (enemy.TryGetComponent(out IHitable hitableEnemy)) {
                hitableEnemy.TakeDamage(damage, gameObject);
            }
        }
    }
    
}
