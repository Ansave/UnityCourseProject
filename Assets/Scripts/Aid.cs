using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aid : MonoBehaviour, IPickable
{
    [SerializeField] private int healthPoints = 30;

    private void OnTriggerEnter(Collider other)
    {
        Picked(other);
    }

    public void Picked(Collider other)
    {
        if (other.TryGetComponent(out Player player)) {
            player.TakeHealing(healthPoints);
        }
        Destroy(gameObject);
    }
}
