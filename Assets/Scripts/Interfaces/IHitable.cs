using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
    void TakeDamage(int inputDamage, GameObject initiator);
    void Die();
}
