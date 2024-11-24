using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public enum E_UILayer
{
    /// <summary>
    /// ��ײ�
    /// </summary>
    Bottom,
    /// <summary>
    /// �в�
    /// </summary>
    Middle,
    /// <summary>
    /// �߲�
    /// </summary>
    Top,
    /// <summary>
    /// ϵͳ�� ��߲�
    /// </summary>
    System,
}
public class UIMgr : Singleton<UIMgr>
{
    private Camera uiCamera;
    private Canvas uiCanvas;
    private EventSystem uiEventSystem;
    //�㼶������
    private Transform bottomLayer;
    private Transform middleLayer;
    private Transform topLayer;
    private Transform systemLayer;
    /// <summary>
    /// ���ڴ洢���е�������
    /// </summary>
    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    private UIMgr()
    {
        //��̬����Ψһ��Canvas��EventSystem�����������һ������û��ʹ�õ�
        //uiCamera =
        //GameObject.Instantiate(ResMgr.GetInstance().GetObject("UI/UICamera")).GetComponent<Camera>();
        //ui��������������Ƴ� ר��������ȾUI���
        //GameObject.DontDestroyOnLoad(uiCamera.gameObject);
        //��̬����Canvas
        uiCanvas =
        GameObject.Instantiate(ResMgr.GetInstance().GetObject("Canvas")).GetComponent<Canvas>();
        //����ʹ�õ�UI�����
        uiCanvas.worldCamera = uiCamera;
        //���������Ƴ�
        GameObject.DontDestroyOnLoad(uiCanvas.gameObject);
        //�ҵ��㼶������
        bottomLayer = uiCanvas.transform.Find("Bottom");
        middleLayer = uiCanvas.transform.Find("Middle");
        topLayer = uiCanvas.transform.Find("Top");
        systemLayer = uiCanvas.transform.Find("System");
        //��̬����EventSystem
        uiEventSystem = GameObject.Instantiate(ResMgr.GetInstance().GetObject("EventSystem")).GetComponent<EventSystem>();
        GameObject.DontDestroyOnLoad(uiEventSystem.gameObject);
    }
    /// <summary>
    /// ��ȡ��Ӧ�㼶�ĸ�����
    /// </summary>
    /// <param name="layer">�㼶ö��ֵ</param>
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
    /// ��ʾ���
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    /// <param name="layer">�����ʾ�Ĳ㼶</param>
    /// <param name="callBack">���ڿ������첽���� ���ͨ��ί�лص�����ʽ ��������ɵ���崫�ݳ�ȥ����ʹ��</param>
    /// <param name="isSync">�Ƿ����ͬ������ Ĭ��Ϊfalse</param>
    public void ShowPanel<T>(E_UILayer layer = E_UILayer.Middle, UnityAction<T> callBack = null, bool
    isSync = false) where T : BasePanel
    {
        //��ȡ����� Ԥ������������������һ��
        string panelName = typeof(T).Name;
        //�������
        if (panelDic.ContainsKey(panelName))
        {
            //���Ҫ��ʾ��� ��ִ��һ������Ĭ����ʾ�߼�
            panelDic[panelName].ShowMe();
            //������ڻص� ֱ�ӷ��س�ȥ����
            callBack?.Invoke(panelDic[panelName] as T);
            return;
        }
        //�����Դû�д洢���ֵ��У���ͨ����Դ������������Դ
        if (!panelDic.ContainsKey(panelName))
        {
            // ���������Դ
            GameObject res = ResMgr.GetInstance().GetObject(panelName);
            // �����Դ�Ƿ���سɹ�
            if (res == null)
            {
                Debug.LogError($"Failed to load panel: {panelName}");
                return;
            }
            // ��ʾ�첽���ؽ���ǰ����Ҫ���ظ������
            // �㼶�Ĵ���
            Transform father = GetLayerFather(layer);
            // ����û�а�ָ�����򴫵ݲ㼶����������Ϊ��
            if (father == null)
                father = middleLayer;
            // �����Ԥ���崴������Ӧ�������£����ұ���ԭ�������Ŵ�С
            GameObject panelObj = GameObject.Instantiate(res, father, false);
            // ��ȡ��Ӧ UI ������س�ȥ
            T panel = panelObj.GetComponent<T>();
            // ��ʾ���ʱִ�е�Ĭ�Ϸ���
            panel.ShowMe();
            // �洢������
            panelDic[panelName] = panel;
            // ����лص���ִ�лص�
            callBack?.Invoke(panel);
        }
    }
    /// <summary>
    /// �������
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    public void HidePanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            //ִ��Ĭ�ϵ����������Ҫ��������
            panelDic[panelName].HideMe();
            //�������
            GameObject.Destroy(panelDic[panelName].gameObject);
            //���������Ƴ�
            panelDic.Remove(panelName);
        }
    }
    /// <summary>
    /// ��ȡ���
    /// </summary>
    /// <typeparam name="T">��������</typeparam>
    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        return null;

    }
}