﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class mSingleton<T>  where T :new()  {

    private static T instance;
    public static T _Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }

}
