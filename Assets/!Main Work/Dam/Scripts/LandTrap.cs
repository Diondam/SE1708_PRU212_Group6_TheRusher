using System;
using _Main_Work.Dam.Scripts.Character;
using UnityEngine;

namespace _Main_Work.Dam.Scripts
{
    public class LandTrap : MonoBehaviour
    {
        public Hero theHero;
        public GameObject effect;
        public float timedelay = 2f;
        public float speedOriginal;
        private void Start()
        {
            theHero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
            speedOriginal = theHero.heroController.m_speed;
        }

        private void OnEnable()
        {
            transform.localScale = transform.localScale * 1.5f;
        }
        public float tempTime = 0f;
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                
                tempTime += Time.deltaTime;
                if(tempTime>timedelay)
                {
                    print("va cham nguoi choi");
                    theHero.TakeDamage(5);
                    theHero.heroController.m_speed = Mathf.Sqrt(theHero.heroController.m_speed);
                    tempTime = 0f;
                }
                
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                theHero.heroController.m_speed = speedOriginal;
            }
        }
    }
}