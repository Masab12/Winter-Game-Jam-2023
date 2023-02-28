using UnityEngine;
using UnityEngine.UI;

public class TimeLimitUI : MonoBehaviour
{
    public TimeLimit timeLimit;
    public Image barImage;

    private float initialWidth;

    private void Start()
    {
        initialWidth = barImage.rectTransform.sizeDelta.x;
    }

    private void Update()
    {
        if (timeLimit.isRunning)
        {
            float ratio = timeLimit.GetRemainingTime() / timeLimit.timeLimitInSeconds;
            barImage.rectTransform.sizeDelta = new Vector2(initialWidth * ratio, barImage.rectTransform.sizeDelta.y);
        }
    }
}