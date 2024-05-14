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
        // ���� �ð��� �����ͼ� �ؽ�Ʈ�� ��ȯ�Ͽ� ǥ��
        DateTime currentTime = DateTime.Now;
        timeText.text = currentTime.ToString("HH : mm");
    }

    public string GetCurrentDate()
    {
        return DateTime.Now.ToString();
    }
}
