using System;
using System.Reflection;
using UnityEngine;
//不继承mono的单例
public abstract class Singleton<T> where T : class
{
    private static T instance;
    public static T GetInstance()
    {
        if (instance == null)
        {
            //获取类型
            Type type = typeof(T);
            //获取无参构造函数
            ConstructorInfo info = type.GetConstructor(BindingFlags.Instance |
            BindingFlags.NonPublic, null, Type.EmptyTypes, null);
            if (info != null)
            {
                instance = info.Invoke(null) as T;
            }
            else
            {
                Debug.Log("没有获取无参构造函数，考虑是否子类没有创建构造函数");
            }
        }
        return instance;
    }
}
//继承mono的
public class SingletonMonoCG<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    public static T Instance
    {
        get
        {
            return instance;
        }
    }
    protected virtual void Awake()
    {
        
        if (instance == null)
        {
            instance = this as T;
        }
    }
}