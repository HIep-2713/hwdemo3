using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:MonoBehaviour
{
    public static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T instanceInScene = FindAnyObjectByType<T>();
                RegisterInstance(instanceInScene);
            }
            return _instance;
        }
       
    }
    public void Awake()
    {
        if (_instance == null)
        {
            RegisterInstance((T)(MonoBehaviour)this);
        }
        else if(_instance != this)
        {
            Destroy(this);
        }

    }
    public static void RegisterInstance(T newInstance)
    {
        if (newInstance == null) return;
        _instance = newInstance;
        DontDestroyOnLoad(_instance.transform.root);

    }
}
