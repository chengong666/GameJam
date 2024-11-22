using System.Collections.Generic;
using UnityEngine.Events;
public class EventMgr : Singleton<EventMgr>
{
    // Start is called before the first frame update
    //����һ���洢�¼����ֵ�
    private EventMgr() { }
    private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string,
    UnityAction<object>>();
    #region ���з���
    /// <summary>
    /// ����¼�
    /// </summary>
    /// <param name="name">ʱ������</param>
    /// <param name="action">��Ϊ</param>
    public void AddLisetenEvent(string name, UnityAction<object> action)
    {
        //��������¼����������Ϊ
        if (eventDic.ContainsKey(name))
        {
            eventDic[name] += action;
        
        }
        else
        {
            //��������ھʹ����¼�
            eventDic.Add(name, action);
        }
    }
    public void EventTrigger(string name, object info = null)
    {
        if (eventDic.ContainsKey(name))
        {
            eventDic[name](info);//info��ʾ����ʲô
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
        //����¼���
        eventDic.Clear();
    }
    #endregion
}