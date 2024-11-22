using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;
/// <summary>
/// 抽象类
/// </summary>
public abstract class BasePanel : MonoBehaviour
{
    /// <summary>
    /// 用于放置UI控件，用父类类型承接子类，用到里氏替换原则
    /// </summary>
    protected Dictionary<string, UIBehaviour> controlDic = new Dictionary<string, UIBehaviour>();
    /// <summary>
    /// 带有以下控件的都是一些默认名字，意味着我们不会通过代码去使用它，这些控件一般只用于显示作用
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
                //为了避免 某一个对象上存在两种控件的情况
                //我们应该优先查找重要的组件如button，toggle，查找顺序即是重要程度
                //即使对象上挂在了多个组件 只要优先找到了重要组件
                //之后也可以通过重要组件得到身上其他挂载的内容
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
    /// 用于显示自己，子类需要重新实现
    /// </summary>
    public abstract void ShowMe();
    /// <summary>
    /// 面板隐藏时会调用的逻辑
    /// </summary>
    public abstract void HideMe();
    public T GetControl<T>(string name) where T : UIBehaviour
    {
        if (controlDic.ContainsKey(name))
        {
            T control = controlDic[name] as T;
            if (control == null) Debug.Log($"不存在对应名字{name},类型为{typeof(T)}的组件");
            return control;
        }
        else
        {
            Debug.LogError($"不存在对应名字为{name}的组件");
            return null;
        }
    }
    /// <summary>
    /// 下面三个用于事件监听时候的回调函数
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
        T[] controls = this.GetComponentsInChildren<T>(true);//true表示是否获取没有激活的对象
        for (int i = 0; i < controls.Length; i++)
        {
            //获取当前控件的名称
            string controlName = controls[i].gameObject.name;
            if (!controlDic.ContainsKey(controlName))
            {
                //添加组件
                controlDic.Add(controlName, controls[i]);
                
            //判断控件类型，并且添加对应的事件
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