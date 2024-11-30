using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBlack : SingletonMonoCG<CameraBlack>
{
    // Start is called before the first frame update
    private void Start()
    {
        // 开始黑屏协程
        //
    }

   public IEnumerator ShowBlackScreen()
   {
       // 显示黑屏
       transform.GetChild(0).gameObject.SetActive(true);
       
       yield return new WaitForSeconds(1f);
       transform.GetChild(0).gameObject.SetActive(false);
   }
}
