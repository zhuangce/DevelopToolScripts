using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Students  {

    public  string PLayerName;

    public int ID;

    public int Age;
    
}

[Serializable]
public class Persons
{
    private static Persons instance;
    public static Persons Instance
    {
        get
        {
            if (instance==null)
            {
                instance = new Persons();
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    public Students[] students;

    public int Amount;
}
