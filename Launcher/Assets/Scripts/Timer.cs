using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine;
using TMPro;


public class Timer: MonoBehaviour
{
    private float _time_start = 60f;
    private float _time_remaining;
    private float _total;

    public event Action TimerEnded;
    public event Action Grow;

    public TextMeshPro text;

    public void Initialize(float time_start)
    {
        _time_start = time_start;
        _time_remaining = _time_start;
        _total = _time_start / 5;
    }

    public void StartTimer()
    {
        Debug.Log(_time_remaining);
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        
        while (_time_remaining > 0)
        {
            yield return new WaitForSeconds(1f);
            _time_remaining--;
            text.text = FormatTime(_time_remaining);

            if (_time_remaining == _total || _time_remaining == _total * 2 || _time_remaining == _total * 3 || _time_remaining == _total * 4)
            {
                PlantGrow();
            }
        }

        TimeEnded();
    }

    public void TimeEnded()
    {
        TimerEnded?.Invoke();
    }

    public void PlantGrow()
    {
        Grow?.Invoke();
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
