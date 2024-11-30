using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            AudioMgr.Instance.PlayAudioSource("翻书2");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && transform.GetChild(0).gameObject.activeSelf)
        {
            AudioMgr.Instance.PlayAudioSource("拧门把手");
            //BornPontsMgr.instance.SetPlayerPos("Born20leftwc");
            //transform.GetChild(0).localScale = new Vector3(3.5f, 3.5f, 3.5f);
            ////Debug.Log("Born" + PlayerCtrl.currentFloor-- + "left");
            ////BornPontsMgr.Instance.SetPlayerPos("Born" + PlayerCtrl.currentFloor-- + "left");

        }
        else if (Input.GetKeyUp(KeyCode.E) && transform.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).localScale = new Vector3(2.288092f, 2.288092f, 2.288092f);
        }
    }
}
