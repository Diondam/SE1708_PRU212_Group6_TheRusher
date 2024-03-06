using System;
using _Main_Work.Dam.Scripts.Character;
using UnityEngine;

namespace _Main_Work.Dam.Scripts
{
    public class SlowArea : MonoBehaviour
    {
        private Hero hero;
        private float speedBefore;
        public float speedSlowArea = 2f;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                hero = other.gameObject.GetComponent<Hero>();
                speedBefore = hero.heroController.m_speed;
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                hero.healthPoint -= 10;
                hero.heroController.m_speed = speedSlowArea;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                hero.heroController.m_speed = speedBefore;
            }
        }
    }
}