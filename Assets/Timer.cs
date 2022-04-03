using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// can be a timer or a countdown 
public class Timer : MonoBehaviour
{
    [Tooltip("Set duration greater than 0 for a count down")]
    public float Duration = 0;
    // When the timer started
    public float TimerStartTime { get; protected set; }

    /// <summary>
    /// All possible timer states
    /// </summary>
    public enum TimerState
    {
        Stopped,
        Started,
        Ended
    }

    // The current game state
    public TimerState State { get; protected set; } = TimerState.Stopped;

    public Text TimerText;

    [Tooltip("Unity Event called on time out")]
    public UnityEvent OnTimeOut;
    protected bool countDown = false;

    public float TimeCount { get; protected set; }


    void OnEnable()
    {
        ResumeTimer();
    }

    public void Start()
    {
        //StartTimer();
    }

    public void StartTimer() // called after OnEnable at scene start
    {
        if(Duration > 0)
            countDown = true;
        TimeCount = Duration;
        State = TimerState.Started;
    }

    void OnDisable()
    {
        StopTimer();
    }

    public void RestartTimer()
    {
        State = TimerState.Started;
        TimeCount = Duration;
    }

    public void StopTimer()
    {
        State = TimerState.Stopped;
    }

    public void ResumeTimer()
    {
        State = TimerState.Started;
    }

    public void Update()
    {
        if (State == TimerState.Started)
        {
            if(countDown)
                TimeCount -= Time.deltaTime; // no change if state is Stopped or Ended
            else
                TimeCount += Time.deltaTime;
        }

        if (TimeCount <= 0f && State != TimerState.Ended && countDown)
        {
            OnTimeOut.Invoke();
            State = TimerState.Ended;
        }

        if (TimerText)
        {
            if (TimeCount < 0f && countDown)
                TimerText.text = "Time Out";
            else
                TimerText.text = TimeCount.ToString("00");
        }
    }
}
