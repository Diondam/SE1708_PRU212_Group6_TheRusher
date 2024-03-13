using System;
using _Main_Work.Dam.Scripts.Character;
using UnityEngine;

namespace _Main_Work.Dam.Scripts
{
    public class LoopTrap : MonoBehaviour
    {
        public Hero theHero;
        public GameObject effect;

        public float length;
     
        private void Start()
        {
            theHero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
        }

        private void OnEnable()
        {
            var offset = transform.localPosition;
            offset.x -= length;
            begin = offset;
            offset.x += length*2;
            end = offset;
        }

        private Vector3 begin;
        private Vector3 end;
        private void Update()
        {
            transform.localPosition = Vector3.Lerp(begin, end, Mathf.PingPong(Time.time, 1));    
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                theHero.TakeDamage(theHero.healthPoint/3);
            }
        }

    }
}