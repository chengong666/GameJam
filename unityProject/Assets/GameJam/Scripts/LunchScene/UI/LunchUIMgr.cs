using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class LunchUIMgr : Singleton<LunchUIMgr>
{
    private Camera uiCamera;
    private Canvas uiCanvas;
    private EventSystem uiEventSystem;
    //层级父对象
    private Transform bottomLayer;
    private Transform middleLayer;
    private Transform topLayer;
    private Transform systemLayer;
    /// <summary>
    /// 用于存储所有的面板对象
    /// </summary>
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    private LunchUIMgr()
    {
        //动态创建唯一的Canvas和EventSystem（摄像机）这一部分我没有使用到
        uiCamera =
        GameObject.Instantiate(ResMgr.GetInstance().GetObject("LunchCamera")).GetComponent<Camera>();
        //ui摄像机过场景不移除 专门用来渲染UI面板
        //GameObject.DontDestroyOnLoad(uiCamera.gameObject);
        //动态创建Canvas
        uiCanvas = GameObject.Instantiate(ResMgr.GetInstance().GetObject("LunchCanvas")).GetComponent<Canvas>();
        //设置使用的UI摄像机
        uiCanvas.worldCamera = uiCamera;
        //过场景不移除
        //GameObject.DontDestroyOnLoad(uiCanvas.gameObject);
        //找到层级父对象
        bottomLayer = uiCanvas.transform.Find("Bottom");
        middleLayer = uiCanvas.transform.Find("Middle");
        topLayer = uiCanvas.transform.Find("Top");
        systemLayer = uiCanvas.transform.Find("System");
        //动态创建EventSystem
        uiEventSystem = GameObject.Instantiate(ResMgr.GetInstance().GetObject("EventSystem")).GetComponent<EventSystem>();
        GameObject.DontDestroyOnLoad(uiEventSystem.gameObject);
    }
    /// <summary>
    /// 获取对应层级的父对象
    /// </summary>
    /// <param name="layer">层级枚举值</param>
    /// <returns></returns>
    public Transform GetLayerFather(E_UILayer layer)
    {
        switch (layer)
        {
            case E_UILayer.Bottom:
                return bottomLayer;
            case E_UILayer.Middle:
                return middleLayer;
            case E_UILayer.Top:
                return topLayer;
            case E_UILayer.System:
                return systemLayer;
            default:
                return null;
        }
    }
    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T">面板的类型</typeparam>
    /// <param name="layer">面板显示的层级</param>
    /// <param name="callBack">由于可能是异步加载 因此通过委托回调的形式 将加载完成的面板传递出去进行使用</param>
    /// <param name="isSync">是否采用同步加载 默认为false</param>
    public void ShowPanel<T>(E_UILayer layer = E_UILayer.Middle, UnityAction<T> callBack = null, bool
    isSync = false) where T : BasePanel
    {
        //获取面板名 预设体名必须和面板类名一致
        string panelName = typeof(T).Name;
        //存在面板
        if (panelDic.ContainsKey(panelName))
        {
            //如果要显示面板 会执行一次面板的默认显示逻辑
            panelDic[panelName].ShowMe();
            //如果存在回调 直接返回出去即可
            callBack?.Invoke(panelDic[panelName] as T);
            return;
        }
        //如果资源没有存储在字典中，就通过资源管理器加载资源
        if (!panelDic.ContainsKey(panelName))
        {
            // 加载面板资源
            GameObject res = ResMgr.GetInstance().GetObject(panelName);
            // 检查资源是否加载成功
            if (res == null)
            {
                Debug.LogError($"Failed to load panel: {panelName}");
                return;
            }
            // 表示异步加载结束前就想要隐藏该面板了
            // 层级的处理
            Transform father = GetLayerFather(layer);
            // 避免没有按指定规则传递层级参数，避免为空
            if (father == null)
                father = middleLayer;
            // 将面板预设体创建到对应父对象下，并且保持原本的缩放大小
            GameObject panelObj = GameObject.Instantiate(res, father, false);
            // 获取对应 UI 组件返回出去
            T panel = panelObj.GetComponent<T>();
            // 显示面板时执行的默认方法
            panel.ShowMe();
            // 存储面板对象
            panelDic[panelName] = panel;
            // 如果有回调，执行回调
            callBack?.Invoke(panel);
        }
    }
    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>
    public void HidePanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            //执行默认的隐藏面板想要做的事情
            panelDic[panelName].HideMe();
            //销毁面板
            GameObject.Destroy(panelDic[panelName].gameObject);
            //从容器中移除
            panelDic.Remove(panelName);
        }
    }
    /// <summary>
    /// 获取面板
    /// </summary>
    /// <typeparam name="T">面板的类型</typeparam>
    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        return null;
    }
}