using System;
using System.Collections;
using System.Collections.Generic;
using _Main_Work.Dam.Scripts.Character;
using UnityEngine;

public class SuddenTrap : MonoBehaviour
{
    
    public Hero theHero;
    public GameObject effect;
    public Transform from;
    public Transform to;
    public float time;
    private void Start()
    {
       
        theHero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        print($"transform.position: {transform.position} fromTemp: {fromTemp} toTemp: {toTemp}");

    }

    private void Awake()
    {
        print("Sudden Trap Awake");
        fromTemp = from.position;
        toTemp = to.position;
    }

    private void OnEnable()
    {
        StartCoroutine("Move");
    }
    
    Vector3  fromTemp;
    Vector3  toTemp;
    IEnumerator Move()
    {
        print($"transform.position: {transform.position} fromTemp: {fromTemp} toTemp: {toTemp}");
        float tempTime = 0f;
        while (tempTime<time)
        {
            tempTime += Time.deltaTime;
            transform.position = Vector3.Lerp(fromTemp, toTemp, tempTime/time);
            print($"transform.position: {transform.position} fromTemp: {fromTemp} toTemp: {toTemp}");
            yield return null;
        }
        
        yield return new WaitForSeconds(time);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theHero.TakeDamage(theHero.healthPoint/3);
        }
    }
    
}
