using System;
using System.Collections;
using System.Collections.Generic;
using _Main_Work.Dam.Scripts;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the gate");
            var gm = FindObjectOfType<GameManager>();
            gm.LoadLevel();
        }
    }
}
