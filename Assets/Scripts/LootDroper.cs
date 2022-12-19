using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDroper : MonoBehaviour
{
    [SerializeField] private GameObject loot;
    [SerializeField] private float dropProbability = 0.5f;

    private void OnDestroy()
    {
        if (this.gameObject.scene.isLoaded) {
            Instantiate(loot, transform.position, transform.rotation);
        }
    }
}
