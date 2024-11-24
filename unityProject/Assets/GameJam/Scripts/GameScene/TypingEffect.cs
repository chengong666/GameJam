using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 如果使用的是普通Text
// using TMPro; // 如果使用的是TextMeshPro

public class TypingEffect : MonoBehaviour
{
    public Text typingText; // 对于普通Text
    // public TextMeshProUGUI typingText; // 对于TextMeshPro
    public string fullText; // 完整的文本
    public float typingSpeed = 0.05f; // 打字速度

    private void Start()
    {
        typingText.text = ""; // 初始化文本为空
        StartCoroutine(TypeText()); // 启动打字效果协程
    }

    private IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            typingText.text += letter; // 添加下一个字符
            yield return new WaitForSeconds(typingSpeed); // 等待指定的时间
        }
    }
}
