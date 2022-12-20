using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Uzi : Weapon
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Vector3 bulletOffset;
    [SerializeField] private float bulletHeight = 4f;
    
    protected override void Attack()
    {
        base.Attack();
        var spawnPosition = transform.position + transform.TransformDirection(bulletOffset);
        var spawnRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        spawnPosition.y = bulletHeight;
        Instantiate(bullet, spawnPosition, spawnRotation).SetActive(true);
    }
}
