using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Uzi : Weapon
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack) {
            Attack();
        }
    }

    
    
}
