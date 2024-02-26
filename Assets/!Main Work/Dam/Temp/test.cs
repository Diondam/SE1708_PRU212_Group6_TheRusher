using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("cáccụ đầu tin");
    }

    private int i = 0;
    // Update is called once per frame
    void Update()
    {
        i++;
        print("Cụ: " + i);
    }
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
    }

    private void OnDisable()
    {
        print("tao là hảo hán cuối cùng");
    }
}
