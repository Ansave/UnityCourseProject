using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("Weapon characteristics")]
    [SerializeField] protected KeyCode button;
    [SerializeField] protected int damage = 25;
    [SerializeField] protected float cooldown = 1f;
    [SerializeField] protected LayerMask enemyLayerMask;
    protected bool canAttack = true;
    
    protected void Update()
    {
        if (Input.GetKeyDown(button) && canAttack) {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        Debug.Log($"{gameObject.name} is attacking");
    }
    
    protected virtual IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}
