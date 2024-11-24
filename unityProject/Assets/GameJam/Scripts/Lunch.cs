using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunch : SingletonMonoCG<Lunch>
{
    
    protected override void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(gameObject);
        ResMgr.GetInstance().AddRes();
        LunchUIMgr.GetInstance().ShowPanel<StartPanel>(E_UILayer.Middle, (a) => { Debug.Log("1" + a.name); });
    }

    void Start()
    {
        //GameApp.instance.GameStart();
    }
}
