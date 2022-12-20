using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text text;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        var currentTime = Time.time - startTime;
        int minutes = (int) currentTime / 60;
        int seconds = (int) currentTime % 60;
        text.text = $"{minutes:D2}:{seconds:D2}";
    }
}
