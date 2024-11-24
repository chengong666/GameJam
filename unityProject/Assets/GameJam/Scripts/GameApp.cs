using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameApp : SingletonMonoCG<GameApp>
{
    //游戏进入逻辑入口
    public void GameStart()
    {
        //进入游戏场景
        this.EnterGameScene();

    }

    private void EnterGameScene()
    {
        //加载游戏场景
        //Debug.Log("加载游戏");
    }
}