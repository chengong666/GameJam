using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ChostCtrl : MonoBehaviour
{
    public GameObject Chost;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Chost = this.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Chost.SetActive(true);
            Player = collision.GetComponent<PlayerCtrl>().gameObject;
            Player.SetActive(false);
            StartCoroutine(up());
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //transform.GetChild(0).gameObject.SetActive(false);
        
    }
    public  IEnumerator up()
    {
        yield return new WaitForSeconds(2);
        Chost.SetActive(false);
        Player.SetActive(true);
        BornPontsMgr.instance.SetPlayerPos("Born20left");
        PlayerCtrl.instance.currentFloor += 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
