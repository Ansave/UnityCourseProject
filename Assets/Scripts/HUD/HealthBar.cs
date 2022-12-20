using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private Player player;
    private Slider slider;
    
    void Start()
    {
        player = Player.instance;
        
        slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = player.maxHealth;
        slider.value = player.health;
        
        GlobalEventManager.OnPlayerHealed.AddListener(UpdateHealthBar);
        GlobalEventManager.OnPlayerRecievedDamage.AddListener(UpdateHealthBar);
    }

    void UpdateHealthBar()
    {
        slider.value = player.health;
    }
}
