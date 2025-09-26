using System;
using UnityEngine;

public class Timer
{
    public float TimeSeconds { get; set; }
    public bool OneShot { get; set; }
    public bool AutoStart { get; set; }
    public bool IsRunning { get; private set; }

    private float _timeLeft;

    public event Action Timeout;

    public Timer(float timeSeconds = 1f, bool oneShot = true, bool autoStart = false)
    {
        TimeSeconds = timeSeconds;
        OneShot = oneShot;
        AutoStart = autoStart;

        if (AutoStart)
            Start();
    }

    public void Start()
    {
        _timeLeft = TimeSeconds;
        IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
    }

    public void Update(float deltaTime)
    {
        if (!IsRunning) return;

        _timeLeft -= deltaTime;

        if (_timeLeft <= 0f)
        {
            Timeout?.Invoke();

            if (OneShot)
            {
                Stop();
            }
            else
            {
                _timeLeft += TimeSeconds;
            }
        }
    }


}
