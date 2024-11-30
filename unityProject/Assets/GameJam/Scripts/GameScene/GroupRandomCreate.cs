using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GroupRandomCreate : SingletonMonoCG<GroupRandomCreate>
{
    [SerializeField]
    Dictionary<string,GameObject> objDic = new Dictionary<string,GameObject>();    
    [SerializeField]
    Dictionary<string,List<string>> SpriteNameGroupEmpty = new Dictionary<string, List<string>>();
    [SerializeField]
    List<GameObject> GameObjLst = new List<GameObject>();
    string s = "宿舍门（1）,宿舍门（2）,宿舍门（3）,厕所门1,Table,Box Volume,LeftExitDoor,Art,Clock,RightExitDoor";
    [SerializeField]
    string s1 = "";
    [SerializeField]
    List<string> spriteName = new List<string>();
    public List<int> FloorStatus = new List<int>() {0, 0, 0, 0, 0, 0};
    
    void Start()
    {
       //用于获取对应资源并进行分类
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log(transform.GetChild(i).name+"111111111");
            objDic.Add(transform.GetChild(i).name, transform.GetChild(i).gameObject);
            GameObjLst.Add(transform.GetChild(i).gameObject);
        }

        string folderPath = "D:\\DeskTop\\GameJamgit\\GameJam\\unityProject\\Assets\\GameJam\\Art\\Sprite";

        // 检查文件夹是否存在
        if (Directory.Exists(folderPath))
        {
            string[] files = Directory.GetFiles(folderPath,"*");
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
            { "钟表", new List<string>
                {
                    "3.00钟表",
                    "12.15钟表",
                }
            },
            { "墙体", new List<string>
                {
                    "中间墙",
                    "右墙",
                    "右衔接墙",
                    "右边墙面窗户",
                    "左墙",
                    "左衔接墙"
                }
            },
            { "宿舍门", new List<string>
                {
                    "门（闭合）",
                    "门（开启）",
                }
            },
             { "厕所门", new List<string>
                {
                    "厕所门正常",
                    "厕所门异常",
                }
            },
            { "楼梯", new List<string>
                {
                    "楼梯"
                }
            },
            { "画", new List<string>
                {
                    "正常画1",
                    "交互画",
                    "正常画2"
                }
            }
        };
        //Debug.Log(SpriteNameGroupEmpty["门"][Random.Range(0, SpriteNameGroupEmpty["门"].Count)]+"11111111");
        //objDic["门"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(SpriteNameGroupEmpty["门"][Random.Range(0, SpriteNameGroupEmpty["门"].Count)]);
        //objDic["宿舍门（2）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(SpriteNameGroupEmpty["门"][Random.Range(0, SpriteNameGroupEmpty["门"].Count)]);
        //objDic["宿舍门（3）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(SpriteNameGroupEmpty["门"][Random.Range(0, SpriteNameGroupEmpty["门"].Count)]);
        //objDic["厕所门1"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(SpriteNameGroupEmpty["门"][Random.Range(0, SpriteNameGroupEmpty["门"].Count)]);
        //objDic["Art"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(SpriteNameGroupEmpty["画"][Random.Range(0, SpriteNameGroupEmpty["画"].Count)]);
        //objDic["Clock"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(SpriteNameGroupEmpty["钟表"][Random.Range(0, SpriteNameGroupEmpty["钟表"].Count)]);
        //foreach (string item in items)
        //{
        //    string trimmedItem = item.Trim();
        //    string baseName = trimmedItem.Split(' ')[0].Split('(')[0].Trim();
        //    Debug.Log(baseName);
        //    if (!SpriteNameGroupEmpty.ContainsKey(baseName))
        //    {
        //        SpriteNameGroupEmpty[baseName] = new List<string>() {"",""};
        //    }
        //    SpriteNameGroupEmpty[baseName].Add(trimmedItem);
        //}

        objDic["宿舍门（1）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][0]);
        objDic["宿舍门（2）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][0]);
        objDic["宿舍门（3）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][0]);
        objDic["厕所门1"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所门"][0]);
        objDic["Art"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["画"][0]);
        objDic["Clock"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["钟表"][0]);
    }

    // Update is called once per frame
    void Update()
    {
    }
    /// <summary>
    /// 处理异常的逻辑
    /// </summary>
    public void ProcessRandom()
    {
        int random = Random.Range(0,2);
        Debug.Log("是否出现异常"+random);
        if (random == 1)
        {
            GameObjLst[5].SetActive(false);
            FloorStatus = new List<int>() { 0, 0, 0, 0, 0, 0 };
            Debug.Log("没有异常");
            Debug.Log("----" + objDic["宿舍门（1）"].gameObject.name);
            objDic["宿舍门（1）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][0]);
            objDic["宿舍门（2）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][0]);
            objDic["宿舍门（3）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][0]);
            objDic["厕所门1"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所门"][0]);
            objDic["Art"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["画"][0]);
            objDic["Clock"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["钟表"][0]);
        }
        else
        {
            //首先是普通异常
            if (true)
            {
                Debug.Log("长度为"+GameObjLst.Count);
                GameObjLst[5].SetActive(true);
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
        FloorStatus = new List<int>() { 0, 0, 0, 0, 0, 0 };
        // 创建一个包含所有指令的列表  
        List<System.Action> actions = new List<System.Action>
        {
            () => {objDic["宿舍门（1）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][Random.Range(1, SpriteNameGroupEmpty["宿舍门"].Count)]);
            FloorStatus[0] = Random.Range(1, SpriteNameGroupEmpty["宿舍门"].Count);
                
            },
            ()=>{
                objDic["宿舍门（2）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][Random.Range(1, SpriteNameGroupEmpty["宿舍门"].Count)]);
                Debug.Log("Sprite/" + SpriteNameGroupEmpty["宿舍门"][Random.Range(1, SpriteNameGroupEmpty["宿舍门"].Count)]);
                FloorStatus[1] = Random.Range(1, SpriteNameGroupEmpty["宿舍门"].Count);
            },
            ()=>{objDic["宿舍门（3）"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["宿舍门"][Random.Range(1, SpriteNameGroupEmpty["宿舍门"].Count)]);
                FloorStatus[2] = Random.Range(1, SpriteNameGroupEmpty["宿舍门"].Count);
 },
            ()=>{objDic["厕所门1"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["厕所门"][Random.Range(1, SpriteNameGroupEmpty["厕所门"].Count)]);
                FloorStatus[3] = Random.Range(1, SpriteNameGroupEmpty["厕所门"].Count);
},
            ()=>{objDic["Art"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["画"][Random.Range(0, SpriteNameGroupEmpty["画"].Count)]);
                FloorStatus[4] = Random.Range(1, SpriteNameGroupEmpty["画"].Count);
},
            ()=>{objDic["Clock"].gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprite/" + SpriteNameGroupEmpty["钟表"][Random.Range(0, SpriteNameGroupEmpty["钟表"].Count)]);
                FloorStatus[5] = Random.Range(1, SpriteNameGroupEmpty["钟表"].Count);
}
    };
        int randomIndex = Random.Range(0, actions.Count);
        actions[randomIndex](); // 执行随机选择的函数  
    }
}
