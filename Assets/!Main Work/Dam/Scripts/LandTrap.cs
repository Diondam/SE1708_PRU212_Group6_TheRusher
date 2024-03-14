using System;
using _Main_Work.Dam.Scripts.Character;
using UnityEngine;

namespace _Main_Work.Dam.Scripts
{
    public class LandTrap : MonoBehaviour
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
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                theHero.TakeDamage(5);
                theHero.heroController.m_speed = (theHero.heroController.m_speed / 2);
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                theHero.heroController.m_speed = (theHero.heroController.m_speed * 2);
            }
        }
    }
}