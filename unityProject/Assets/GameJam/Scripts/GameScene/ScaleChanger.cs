using System.Collections;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    // 目标缩放值
    public Vector3 targetScale = new Vector3(0.227321f, 0.227321f, 0.227321f);
    // 缩放速度
    public float scaleSpeed = 0.05f;

    private void Start()
    {
        // 开始协程
        StartCoroutine(ChangeScale());
    }

    private IEnumerator ChangeScale()
    {
        // 当前缩放
        Vector3 initialScale = transform.localScale;

        // 循环直到达到目标缩放
        while (Vector3.Distance(transform.localScale, targetScale) > 0.01f)
        {
            // 逐渐改变缩放
            transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
            yield return null; // 等待下一帧
        }

        // 确保最后的缩放值是目标值
        transform.localScale = targetScale;
    }
}
