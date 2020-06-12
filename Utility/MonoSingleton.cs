using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T>
{

    private static T instance; 
    public static T Instance
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        // DontDestroyOnLoad(gameObject);
         // instance = this as T;


    }

    public void Test()
    {
        Debug.Log("SIngleton");
    }

}
