using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WCRandomCreate : SingletonMonoCG<WCRandomCreate>
{
    [SerializeField]
    Dictionary<string, GameObject> WCobjDic = new Dictionary<string, GameObject>();
    [SerializeField]
    Dictionary<string, List<string>> SpriteNameGroupEmpty = new Dictionary<string, List<string>>();
    [SerializeField]
    List<GameObject> GameObjLst = new List<GameObject>();
    string s = "宿舍门（1）,宿舍门（2）,宿舍门（3）,厕所门1,Table,Box Volume,LeftExitDoor,Art,Clock,RightExitDoor";
    [SerializeField]
    string s1 = "";
    [SerializeField]
    List<string> spriteName = new List<string>();
    public List<int> WCStatus = new List<int>() { 0, 0, 0, 0, 0, 0 ,0,0,0,0,0,0,0, 0, 0, 0, 0, 0, 0 };

    void Start()
    {
        //用于获取对应资源并进行分类
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log(transform.GetChild(i).name + "111111111");
            WCobjDic.Add(transform.GetChild(i).name, transform.GetChild(i).gameObject);
            GameObjLst.Add(transform.GetChild(i).gameObject);
        }
        string folderPath = "D:\\DeskTop\\GameJamgit\\GameJam\\unityProject\\Assets\\GameJam\\Art\\Sprite";

        // 检查文件夹是否存在
        if (Directory.Exists(folderPath))
        {
            string[] files = Directory.GetFiles(folderPath, "*");
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                spriteName.Add(fileName);
                s1 += fileName;
            }
        }
        else
        {
            Debug.LogError("指定的文件夹不存在: " + folderPath);
        }

        string[] items = s.Split(',');
        SpriteNameGroupEmpty = new Dictionary<string, List<string>>()
        {
            { "小便池类", new List<string>
                {
                    "小便池",
                    "",
                }
            },
            { "血迹类", new List<string>
                {
                ""
                ,"厕所血迹"
                }
            },
            { "宿管腿类", new List<string>
                {
                    "",
                    "厕所的脚",
                }
            },
             { "厕所隔间类", new List<string>
                {
                    "厕所隔间",
                    "",
                }
            },
           { "厕所内门类", new List<string>
                {
                    "厕所内门",
                    "",
                }
            },
        };

        WCobjDic["小便池"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
        WCobjDic["小便池 (1)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
        WCobjDic["小便池 (2)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
        WCobjDic["小便池 (3)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
        WCobjDic["小便池 (4)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
        
        WCobjDic["厕所隔间"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
        WCobjDic["厕所隔间 (1)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
        WCobjDic["厕所隔间 (2)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
        WCobjDic["厕所隔间 (3)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
        WCobjDic["厕所隔间 (4)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
        
        WCobjDic["厕所内门"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所内门类"][0]);
        
        WCobjDic["宿管脚 (1)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿管腿类"][0]);
        
        WCobjDic["厕所血迹"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["血迹类"][0]);
        ProcessRandomWc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 处理异常的逻辑
    /// </summary>
    public void ProcessRandomWc()
    {
        int random = Random.Range(0, 2);
        Debug.Log("是否出现异常" + random);
        if (random == 1)
        {
            
            WCStatus = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Debug.Log("没有异常");

            WCobjDic["小便池"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
            WCobjDic["小便池 (1)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
            WCobjDic["小便池 (2)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
            WCobjDic["小便池 (3)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);
            WCobjDic["小便池 (4)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][0]);

            WCobjDic["厕所隔间"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
            WCobjDic["厕所隔间 (1)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
            WCobjDic["厕所隔间 (2)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
            WCobjDic["厕所隔间 (3)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);
            WCobjDic["厕所隔间 (4)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][0]);

            WCobjDic["厕所内门"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所内门类"][0]);

            WCobjDic["宿管脚 (1)"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿管腿类"][0]);

            WCobjDic["厕所血迹"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["血迹类"][0]);
        }
        else
        {
            //首先是普通异常
            if (true)
            {
                Debug.Log("有异常出现");
                ExecuteRandomSpriteChange();
            }
        }
    }

    /// <summary>
    /// 选一个异常出来
    /// </summary>
    public void ExecuteRandomSpriteChange()
    {
        WCStatus = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        // 创建一个包含所有指令的列表  
        List<System.Action> actions = new List<System.Action>
{  
 

    // 设置厕所隔间  
    () => {
        for (int i = 0; i <= 4; i++) {
            string key = i == 0 ? "厕所隔间" : $"厕所隔间 ({i})";
            WCobjDic[key].gameObject.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所隔间类"][Random.Range(1, SpriteNameGroupEmpty["厕所隔间类"].Count)]);
            WCStatus[i] = Random.Range(1, SpriteNameGroupEmpty["厕所隔间类"].Count);
        }
    },  

    // 设置厕所内门  
    () => {
        WCobjDic["厕所内门"].gameObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所内门类"][Random.Range(1, SpriteNameGroupEmpty["厕所内门类"].Count)]);
        WCStatus[5] = Random.Range(1, SpriteNameGroupEmpty["厕所内门类"].Count);
        if (WCStatus[5]==1)
        {
            Debug.Log("没有门，你出不去了");
            WCobjDic["厕所内门"].gameObject.SetActive(false);
            StartCoroutine(faildToBorn());
        }
    },  

    // 设置宿管脚（使用固定精灵）  
    () => {
        WCobjDic["宿管脚 (1)"].gameObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿管腿类"][Random.Range(1, SpriteNameGroupEmpty["宿管腿类"].Count)]);
        WCStatus[6] = Random.Range(1, SpriteNameGroupEmpty["宿管腿类"].Count);
    },  

    // 设置厕所血迹  
    () => {
        WCobjDic["厕所血迹"].gameObject.GetComponent<SpriteRenderer>().sprite
            = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["血迹类"][Random.Range(1, SpriteNameGroupEmpty["血迹类"].Count)]);
        WCStatus[7] = Random.Range(1, SpriteNameGroupEmpty["血迹类"].Count);
    },  

        // 设置小便池  
    () => {
        for (int i = 0; i <= 4; i++) {
            string key = i == 0 ? "小便池" : $"小便池 ({i})";
            WCobjDic[key].gameObject.GetComponent<SpriteRenderer>().sprite
                = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["小便池类"][Random.Range(1, SpriteNameGroupEmpty["厕所隔间类"].Count)]);
            WCStatus[i+13] = Random.Range(1, SpriteNameGroupEmpty["厕所隔间类"].Count);
        }
    },
};
        int randomIndex = Random.Range(0, actions.Count);
        actions[randomIndex](); // 执行随机选择的函数  
    }
    public IEnumerator faildToBorn()
    {
        yield return new WaitForSeconds(5);
        PlayerCtrl.Instance.currentFloor = 15;
        BornPontsMgr.Instance.SetPlayerPos("Bornleft");
    }
}
