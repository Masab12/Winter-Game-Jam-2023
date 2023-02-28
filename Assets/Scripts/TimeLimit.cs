using UnityEngine;

public class TimeLimit : MonoBehaviour
{
    public float timeLimitInSeconds = 60f;
    public bool isRunning = false;

    public delegate void TimeUpEventHandler();
    public event TimeUpEventHandler OnTimeUp;

    private float remainingTimeInSeconds;

    private void Start()
    {
        remainingTimeInSeconds = timeLimitInSeconds;
    }

    private void Update()
    {
        if (isRunning)
        {
            remainingTimeInSeconds -= Time.deltaTime;

            if (remainingTimeInSeconds <= 0)
            {
                remainingTimeInSeconds = 0;
                isRunning = false;

                OnTimeUp?.Invoke(); // Fire the TimeUp event
            }
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetRemainingTime()
    {
        return remainingTimeInSeconds;
    }
}