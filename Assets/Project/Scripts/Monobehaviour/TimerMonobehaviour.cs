using UnityEngine;
using UnityEngine.Events;

public class TimerMonobehaviour : MonoBehaviour
{
    [SerializeField] public float TimeSeconds;
    [SerializeField] public bool OneShot;
    [SerializeField] public bool AutoStart;
    [HideInInspector]public bool IsRunning { get; private set; }

    public UnityEvent Timeout;

    private Timer timer;

    void Awake()
    {
        timer = new Timer(TimeSeconds, OneShot, AutoStart);
        timer.Timeout += TimeoutCallback;
    }

    public void StartTimer() => timer.Start();
    public void StopTimer() => timer.Stop();

    void Update()
    {
        timer.Update(Time.deltaTime);
    }

    private void TimeoutCallback()
    {
        Timeout?.Invoke();
    }
}
