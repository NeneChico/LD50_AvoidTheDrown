using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("Game ends after this many seconds have elapsed")]
    public float Duration = 60;
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

    public float TimeRemaining { get; protected set; }


    void OnEnable()
    {
        ResumeTimer();
    }

    public void Start() // called after OnEnable at scene start
    {
        TimeRemaining = Duration;
        State = TimerState.Stopped;
    }

    void OnDisable()
    {
        StopTimer();
    }

    public void RestartTimer()
    {
        State = TimerState.Started;
        TimeRemaining = Duration;
    }

    public void StopTimer()
    {
        State = TimerState.Stopped;
    }

    public void ResumeTimer()
    {
        State = TimerState.Stopped;
    }

    public void Update()
    {
        if (State == TimerState.Started)
        {
            TimeRemaining -= Time.deltaTime; // no change if state is Stopped or Ended
        }

        if (TimeRemaining <= 0f && State != TimerState.Ended)
        {
            OnTimeOut.Invoke();
            State = TimerState.Ended;
        }

        if (TimerText)
        {
            if (TimeRemaining > 0f)
                TimerText.text = TimeRemaining.ToString("00");
            else
            {
                TimerText.text = "Time Out";
            }
        }
    }
}
