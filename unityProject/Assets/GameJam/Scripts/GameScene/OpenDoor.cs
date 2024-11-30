using ClipperLib;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using UnityEngine;
public class OpenDoor : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
       transform.GetChild(0).gameObject.SetActive(true);
   }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& transform.GetChild(0).gameObject.activeSelf)
        {
            Debug.Log(gameObject.name);
            switch (gameObject.name)
            {
                case "LeftExitDoorC":
                    BornPontsMgr.instance.SetPlayerPos("Bornleft");
                    if (WCRandomCreate.Instance.WCStatus.Sum() + GroupRandomCreate.Instance.FloorStatus.Sum() >= 1)
                    {
                        PlayerCtrl.Instance.currentFloor -= 1;
                        PlayerCtrl.Instance.currentFloor = Mathf.Clamp(PlayerCtrl.Instance.currentFloor,1,15);
                    }
                    else
                    {
                        PlayerCtrl.Instance.currentFloor += 1;
                        PlayerCtrl.Instance.currentFloor = Mathf.Clamp(PlayerCtrl.Instance.currentFloor, 1, 15);
                    }
                    GroupRandomCreate.Instance.ProcessRandom();
                    WCRandomCreate.Instance.ProcessRandomWc();
                    break;
                case "RightExitDoorC":
                    BornPontsMgr.instance.SetPlayerPos("Bornleft");
                    Debug.Log("重新生成楼");

                    if (WCRandomCreate.Instance.WCStatus.Sum() + GroupRandomCreate.Instance.FloorStatus.Sum() >= 1)
                    {
                        Debug.Log("上楼");
                        PlayerCtrl.Instance.currentFloor += 1;
                        PlayerCtrl.Instance.currentFloor = Mathf.Clamp(PlayerCtrl.Instance.currentFloor, 1, 15);
                    }
                    else
                    {
                        Debug.Log("下楼");
                        PlayerCtrl.Instance.currentFloor -= 1;
                        PlayerCtrl.Instance.currentFloor = Mathf.Clamp(PlayerCtrl.Instance.currentFloor, 1, 15);
                    }
                    GroupRandomCreate.Instance.ProcessRandom();
                    WCRandomCreate.Instance.ProcessRandomWc();
                    break;
                case"厕所门1":
                    BornPontsMgr.instance.SetPlayerPos("BornWc");
                    
                    break;
                case "厕所内门":
                    BornPontsMgr.instance.SetPlayerPos("BornWcBack");
                    break;
                default:
                    AudioMgr.Instance.PlayAudioSource("拧门把手");
                    break;
            }
            transform.GetChild(0).localScale = new Vector3(3.5f,3.5f,3.5f);
        }
        else if (Input.GetKeyUp(KeyCode.E) && transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).localScale = new Vector3(2.288092f, 2.288092f, 2.288092f);
        }
    }
}
