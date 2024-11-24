using UnityEngine;
using UnityEngine.UI; // 如果使用的是普通Text
// using TMPro; // 如果使用的是TextMeshPro

public class Timer : MonoBehaviour
{
    public Text timerText; // 对于普通Text
    // public TextMeshProUGUI timerText; // 对于TextMeshPro
    private float timeElapsed = 0f;
    private bool isRunning = true;
    
    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime; // 增加经过的时间
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        // 将时间格式化为分钟:秒
        float minutes = Mathf.FloorToInt(timeElapsed / 60);
        float seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        isRunning = false; // 停止计时器
    }

    public void StartTimer()
    {
        isRunning = true; // 启动计时器
    }

    public void ResetTimer()
    {
        timeElapsed = 0f; // 重置计时器
        UpdateTimerText();
    }
}
