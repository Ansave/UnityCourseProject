using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDroper : MonoBehaviour
{
    [SerializeField] private GameObject loot;

    private void OnDestroy()
    {
        if (this.gameObject.scene.isLoaded) {
            Instantiate(loot, transform.position, transform.rotation);
        }
    }
}
