using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : SingletonMonoCG<PlayerCtrl>
{
    public Text floorNum;
    public  int currentFloor = 15;
    void Start()
    {
        StartCoroutine(ChangePos());
    }

    IEnumerator ChangePos()
    {
        yield return new WaitForEndOfFrame();
        BornPontsMgr.instance.SetPlayerPos("Bornleft");
    }

    void Update()
    {
        //更新楼层
        floorNum.text = currentFloor.ToString();

    }
}
