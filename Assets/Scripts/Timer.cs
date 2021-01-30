using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool bHasStarted = false;
    [SerializeField]
    private TextMeshProUGUI TimerText;
    public void StartTimer()
    {
        if (!TimerText)
        {
            TimerText = GetComponent<TextMeshProUGUI>();
        }

        bHasStarted = true;
        InvokeRepeating("UpdateTimer", 0.5f, 0.5f);
    }


    string GetTimer()
    {
        float Remaining = GameManager.Instance.GetCurrentDuration();
        var ts = TimeSpan.FromSeconds(Remaining);
        return string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
    }

    void UpdateTimer()
    {
        if (bHasStarted)
        {
            TimerText.SetText(GetTimer());
        }
        else
        {
            TimerText.SetText("");
            CancelInvoke("UpdateTimer");
        }
    }
}
