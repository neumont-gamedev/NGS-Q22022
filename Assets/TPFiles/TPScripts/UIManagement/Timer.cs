using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static float timer = -1f;

    [SerializeField]
    public int numberAudioPlays = 3;
    public GameObject timerObject;
    public AudioSource timerAudio;

    private bool isTimerStarted = false;
    private TMP_Text timerText;
    private TimeSpan ts;

    void Start()
    {
        timerText = timerObject.GetComponentInChildren<TMP_Text>();
        timerObject.SetActive(false);
    }

    void Update()
    {
        if (isTimerStarted) return;

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            StartCoroutine(TimerCo(60f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            StartCoroutine(TimerCo(120f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            StartCoroutine(TimerCo(180f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            StartCoroutine(TimerCo(240f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            StartCoroutine(TimerCo(300f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            StartCoroutine(TimerCo(360));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            StartCoroutine(TimerCo(420f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            StartCoroutine(TimerCo(480f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            StartCoroutine(TimerCo(540f));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            StartCoroutine(TimerCo(600f));
        }
    }

    IEnumerator TimerCo(float time)
    {
        isTimerStarted = true;
        Timer.timer = time;
        timerObject.SetActive(true);

        while (Timer.timer >= 0f)
        {
            Timer.timer -= Time.deltaTime;
            ts = TimeSpan.FromSeconds(Timer.timer);
            timerText.text = $"{ts.Minutes:D2}:{ts.Seconds:D2}";
            yield return false;
        }

        for (int i = 0; i < numberAudioPlays + 1; i++)
        {
            if (timerAudio.isPlaying) i--;
            else timerAudio.Play();

            yield return false;
        }

        timerObject.SetActive(false);
        isTimerStarted = false;
        yield return true;
    }
}
