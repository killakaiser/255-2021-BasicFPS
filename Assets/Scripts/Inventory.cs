using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Singleton design pattern
    private static Inventory _main;
    public static Inventory main
    {
        get { return _main; }
    }

    public bool hasKey = false;


    private void Start()
    {
        if (_main == null)
        {
            _main = this;
            DontDestroyOnLoad(gameObject);
            //dont destroy this object when loading a new scene

        }else {
            Destroy(gameObject); // destroy this extra inventory system

        }
    }
}

