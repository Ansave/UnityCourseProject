using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject sword;
    public bool canAttack = true;
    public int damage = 25;
    public float cooldown = 1f;
    public float attackRadius = 20f;
    public float explosionForse = 20f;
    private static readonly int PrimaryWeaponAttack = Animator.StringToHash("PrimaryWeaponAttack");
    private LayerMask enemyLayerMask;
    
    private Animator weaponAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyLayerMask = LayerMask.GetMask("Enemy");
        weaponAnimator = sword.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack) {
            Attack();
        }
    }
    
    void Attack()
    {
        weaponAnimator.SetTrigger(PrimaryWeaponAttack);
        StartCoroutine(AttackCooldown());
        
        Collider[] hittedEnemies = Physics.OverlapSphere(transform.position, attackRadius, enemyLayerMask);

        foreach (var enemy in hittedEnemies) {
            
            if (enemy.TryGetComponent(out Rigidbody enemyRigitbody)) {
                enemyRigitbody.AddExplosionForce(explosionForse, transform.position, attackRadius);
            }

            if (enemy.TryGetComponent(out IHitable hitableEnemy)) {
                hitableEnemy.TakeDamage(damage, gameObject);
            }
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
