using System;
using System.Reflection;
using UnityEngine;
//���̳�mono�ĵ���
public abstract class Singleton<T> where T : class
{
    private static T instance;
    public static T GetInstance()
    {
        if (instance == null)
        {
            //��ȡ����
            Type type = typeof(T);
            //��ȡ�޲ι��캯��
            ConstructorInfo info = type.GetConstructor(BindingFlags.Instance |
            BindingFlags.NonPublic, null, Type.EmptyTypes, null);
            if (info != null)
            {
                instance = info.Invoke(null) as T;
            }
            else
            {
                Debug.Log("û�л�ȡ�޲ι��캯���������Ƿ�����û�д������캯��");
            }
        }
        return instance;
    }
}
//�̳�mono��
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