using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private Timer timer;
    private int seconds = 0;
    private int minutes = 0;

    private void Awake()
    {
        timer = new Timer(1.0f, false);
        timer.Timeout += OnTimeout;
        timer.Start();
    }

    private void Update()
    {
        timer.Update(Time.deltaTime);
    }

    private void OnTimeout()
    {
        seconds++;
        if(seconds >=60)
        {
            seconds -= 60;
            minutes++;
        }

        string strsec = seconds.ToString();
        string strmin = minutes.ToString();
        if(seconds <10)
        {
            strsec = "0" + seconds;
        }
        if(minutes <10)
        {
            strmin = "0" + minutes;
        }

        text.text = strmin + ":" + strsec;
    }
}
