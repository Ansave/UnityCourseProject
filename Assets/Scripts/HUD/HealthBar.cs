using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public PlayerCombat playerCombat;
    private Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = playerCombat.maxHealth;
        slider.value = playerCombat.health;
        
        GlobalEventManager.OnPlayerHealed.AddListener(UpdateHealthBar);
        GlobalEventManager.OnPlayerRecievedDamage.AddListener(UpdateHealthBar);
    }

    void UpdateHealthBar()
    {
        slider.value = playerCombat.health;
    }
}
