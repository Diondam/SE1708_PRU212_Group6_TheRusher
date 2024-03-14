using System;
using System.Collections;
using System.Collections.Generic;
using _Main_Work.Dam.Scripts.Character;
using UnityEngine;

public class DropTrap : MonoBehaviour
{
    
    
    public Hero theHero;
    public GameObject effect;
    private void Start()
    {
        theHero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
    }

    private void OnEnable()
    {
        transform.localScale = transform.localScale * 1.5f;
        Invoke("Destroy", 2f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theHero.TakeDamage(theHero.healthPoint+10);
        }
    }
}
