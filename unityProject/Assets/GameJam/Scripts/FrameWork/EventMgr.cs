using System.Collections.Generic;
using UnityEngine.Events;
public class EventMgr : Singleton<EventMgr>
{
    // Start is called before the first frame update
    //定义一个存储事件的字典
    private EventMgr() { }
    private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string,
    UnityAction<object>>();
    #region 公有方法
    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="name">时间名称</param>
    /// <param name="action">行为</param>
    public void AddLisetenEvent(string name, UnityAction<object> action)
    {
        //如果存在事件就添加是行为
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] += action;
        
        }
        else
        {
            //如果不存在就创建事件
            eventDic.Add(name, action);
        }
    }
    public void EventTrigger(string name, object info = null)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name](info);//info表示的是什么
        }
    }
    public void RemoveEvent(string name, UnityAction<object> action)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] -= action;
        }
    }
    public void ClearEvent()
    {
        //清空事件池
        eventDic.Clear();
    }
    #endregion
}