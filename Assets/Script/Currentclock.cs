using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Currentclock : MonoBehaviour
{

    public Text text_date;
    public Text text_time;

    private void Start()
    {
        Init_Time();
    }

    private void Init_Time()
    {
        if (IsInvoking("Update_Time"))
            CancelInvoke("Update_Time");
        InvokeRepeating("Update_Time", 0, 0.2f);
    }

    private void Update_Time()
    {
        string date = DateTime.Now.ToString("yyyy.MM.dd ") + DateTime.Now.DayOfWeek.ToString().ToUpper().Substring(0, 3);
        //or date = DateTime.Now.ToString("yyyy. MM. dd. ddd");
        string time = DateTime.Now.ToString("HH:mm:ss");
        text_date.text = date;
        text_time.text = time;

        Debug.Log(string.Format("{0}\n{1}", date, time));

    }
}
