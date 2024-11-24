using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    protected override void Awake()
    { 
        base.Awake();
    }
    public override void ShowMe()
    {
        gameObject.SetActive(true);
    }

    public override void HideMe()
    {
        gameObject.SetActive(false);
    }
    protected override void ClickBtn(string btnName)
    {
        
        switch (btnName)
        {
            case "StartBtn":
                Debug.Log("跳转到游戏场景");
                SceneManager.LoadScene("Game");
                break;
            case "SettingBtn":
                GetControl<Image>("SettingBk").gameObject.SetActive(true);
                Debug.Log("游戏设置场景");
                break;
            case "GuideBtn":
                GetControl<Image>("AboutBk").gameObject.SetActive(true);
                Debug.Log("关于");
                break;
            case "ExitBtn":
                Debug.Log("退出游戏");
                break;
            case "ExitAb":
                Debug.Log("退出游戏");
                GetControl<Image>("AboutBk").gameObject.SetActive(false);
                break;
            case "ExitSe":
                GetControl<Image>("SettingBk").gameObject.SetActive(false);
                Debug.Log("退出游戏");
                break;
        }
    }
}
