using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class foodEating : MonoBehaviour
{
    public GameObject Timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButtonDown(0)) // 0表示左键
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Clicked on: " + hit.transform.name);
                // 这里可以添加更多交互逻辑
                if (hit.transform.name == "TrueFood")
                {
                    Debug.Log("吃错了");
                    Timer.SetActive(true);
                    hit.transform.gameObject.SetActive(false);
                }
                //hit.transform.GetComponent<SpriteRenderer>().color = Color.red; // 改变颜色
               
            }
        }
    }


}
