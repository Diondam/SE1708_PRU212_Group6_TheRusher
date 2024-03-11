using System;
using System.Collections;
using System.Collections.Generic;
using _Main_Work.Dam.Scripts.Character;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int PlusHealth = 25;
    public int PlusSpeed = 4;
    
    private void  OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the Buff");
            var hero = other.gameObject.GetComponent<Hero>();
            hero.healthPoint += 25;
            hero.heroController.m_speed += 4;
            Invoke("DelayMethod", -.2f);
        }
    }

  
    void DelayMethod()
    {
        Destroy(gameObject);
    }
    
}
