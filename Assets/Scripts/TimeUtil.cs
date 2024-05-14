using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUtil : MonoBehaviour
{
    public Text timeText;

    void Update()
    {
        // 현재 시간을 가져와서 텍스트로 변환하여 표시
        DateTime currentTime = DateTime.Now;
        timeText.text = currentTime.ToString("HH : mm");
    }

    public string GetCurrentDate()
    {
        return DateTime.Now.ToString();
    }
}
