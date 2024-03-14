using System;
using System.Collections;
using System.Collections.Generic;
using _Main_Work.Dam.Scripts.Character;
using UnityEngine;

public class MoveTrap : MonoBehaviour
{
    public Hero theHero;
    public GameObject effect;
    public Rigidbody2D rb;
    public float force = 100f;

    private void Start()
    {
        theHero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
    }

    private void Awake()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
    }
    

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            rb.AddForce(Vector2.left * force, ForceMode2D.Force);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theHero.TakeDamage(theHero.healthPoint / 3);
        }
    }
}