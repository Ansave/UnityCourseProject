using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private int stage = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.minValue = 0;
        slider.maxValue = EnemyWaveManager.instance.transform.childCount;
        
        GlobalEventManager.OnWaveEliminated.AddListener(UpdateProgressBar);
    }

    // Update is called once per frame
    void UpdateProgressBar()
    {
        stage++;
        slider.value = stage;
    }
}
