using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField]
    private float TimeMultipler;

    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;

    [SerializeField]
    private float sunsetHour;

    private DateTime currentTime;

    private TimeSpan sunriseTime;

    private TimeSpan sunsetTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);

        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * TimeMultipler);

        if (timeText != null)
        {
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;
    }
}
