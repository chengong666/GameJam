using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;
/// <summary>
/// ������
/// </summary>
public abstract class BasePanel : MonoBehaviour
{
    /// <summary>
    /// ���ڷ���UI�ؼ����ø������ͳн����࣬�õ������滻ԭ��
    /// </summary>
    protected Dictionary<string, UIBehaviour> controlDic = new Dictionary<string, UIBehaviour>();
    /// <summary>
    /// �������¿ؼ��Ķ���һЩĬ�����֣���ζ�����ǲ���ͨ������ȥʹ��������Щ�ؼ�һ��ֻ������ʾ����
    /// </summary>
    private static List<string> defaultName = new List<string>() { "Image",
                                                                "Text (TMP)",
                                                                "RawImage",
                                                                "Background",
                                                                "Checkmark",
                                                                "Label",
                                                                "Text (Legacy)",
                                                                "Arrow",
                                                                "Placeholder",
                                                                "Fill",
                                                                "Handle",
                                                                "Viewport",
                                                                "Scrollbar Horizontal",
                                                                "Scrollbar Vertical"};
        protected virtual void Awake()
        {
                //Ϊ�˱��� ĳһ�������ϴ������ֿؼ������
                //����Ӧ�����Ȳ�����Ҫ�������button��toggle������˳������Ҫ�̶�
                //��ʹ�����Ϲ����˶����� ֻҪ�����ҵ�����Ҫ���
                //֮��Ҳ����ͨ����Ҫ����õ������������ص�����
                FindChildrenControl<Button>();
                FindChildrenControl<Toggle>();
                FindChildrenControl<Slider>();
                FindChildrenControl<InputField>();
                FindChildrenControl<ScrollRect>();
                FindChildrenControl<Dropdown>();
                FindChildrenControl<Text>();
                FindChildrenControl<TextMeshPro>();
                FindChildrenControl<Image>();
        }
    /// <summary>
    /// ������ʾ�Լ���������Ҫ����ʵ��
    /// </summary>
    public abstract void ShowMe();
    /// <summary>
    /// �������ʱ����õ��߼�
    /// </summary>
    public abstract void HideMe();
    public T GetControl<T>(string name) where T : UIBehaviour
    {
        if (controlDic.ContainsKey(name))
        {
            T control = controlDic[name] as T;
            if (control == null) Debug.Log($"�����ڶ�Ӧ����{name},����Ϊ{typeof(T)}�����");
            return control;
        }
        else
        {
            Debug.LogError($"�����ڶ�Ӧ����Ϊ{name}�����");
            return null;
        }
    }
    /// <summary>
    /// �������������¼�����ʱ��Ļص�����
    /// </summary>
    /// <param></param>
    protected virtual void ClickBtn(string btnName)
    {
    }
    protected virtual void SliderValueChange(string sliderName, float value)
    {
    }
    protected virtual void ToggleValueChange(string sliderName, bool value)
    {
    }
    void Update()
    {
    }
    private void FindChildrenControl<T>() where T : UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>(true);//true��ʾ�Ƿ��ȡû�м���Ķ���
        for (int i = 0; i < controls.Length; i++)
        {
            //��ȡ��ǰ�ؼ�������
            string controlName = controls[i].gameObject.name;
            if (!controlDic.ContainsKey(controlName))
            {
                //������
                controlDic.Add(controlName, controls[i]);
                
            //�жϿؼ����ͣ�������Ӷ�Ӧ���¼�
                if (controls[i] is Button)
                {
                    (controls[i] as Button).onClick.AddListener(() => { ClickBtn(controlName); });
                }
                else if (controls[i] is Slider)
                {
                    (controls[i] as Slider).onValueChanged.AddListener((value) =>
                    {
                        SliderValueChange(controlName, value);
                    });
                }
                else if (controls[i] is Toggle)
                {
                    (controls[i] as Toggle).onValueChanged.AddListener((value) =>
                    {
                        ToggleValueChange(controlName, value);
                    });
                }
            }
        }
    }
}