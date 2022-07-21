using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaytimeTimer : MonoBehaviour
{ 
    private bool timerActive = false;
    public TMP_Text m_timer;
    private float m_TimeBase = 60;
    public float m_Time = 60;
    private int m_Multiplier = 1;

    void Start()
    {
       
    }

    void Update()
    {
        if(Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                m_Multiplier = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                m_Multiplier = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                m_Multiplier = 3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                m_Multiplier = 4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                m_Multiplier = 5;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                m_Multiplier = 6;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                m_Multiplier = 7;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                m_Multiplier = 8;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                m_Multiplier = 9;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                m_Multiplier = 10;
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                SetTimer();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if(!timerActive && m_Time > 1)
                {
                    timerActive = true;
                }
                else
                {
                    timerActive = false;
                }
            }
        }
        if(timerActive)
        {
            if(m_Time > 0)
            {
                m_Time = m_Time - Time.deltaTime;
                UpdateTimer();
            }
            else
            {
                m_Time = 0;
                timerActive = false;
                m_timer.SetText("0:00");
                Application.LoadLevel(0);
            }
        }
    }

    void SetTimer()
    {
        timerActive = true;
        m_Time = m_TimeBase * m_Multiplier;
    }

    void UpdateTimer()
    {
        int min = (int)m_Time / 60;
        int sec = (int)m_Time % 60;
        m_timer.SetText(min + ":" + sec);
    }
}
