using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Update()
    {
        int minutes = (int) Time.time / 60;
        int seconds = (int) Time.time % 60;
        text.text = $"{minutes:D2}:{seconds:D2}";
    }
}
