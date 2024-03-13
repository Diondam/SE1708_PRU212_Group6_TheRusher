using System;
using UnityEngine;

namespace _Main_Work.Dam.Scripts.Character.Enemy.BulletEnemy
{
    public class Bullet : MonoBehaviour
    {
        public Hero theHero;
        public float timeToLive = 5;
        public GameObject effect;
        private void Start()
        {
            theHero = GameObject.FindGameObjectWithTag("Player").GetComponent<Hero>();
            Invoke("UnActive", timeToLive);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
            {
                theHero.TakeDamage(10);
                Instantiate(effect, transform.position, Quaternion.identity);
                UnActive();
            }
        }

        void UnActive()
        {
            gameObject.SetActive(false);
        }

        public float timeTemp = 0;

        private void Update()
        {
            if (gameObject.activeInHierarchy)
            {
                transform.position = Vector3.Lerp(transform.position, theHero.transform.position, timeTemp / 5);
                timeTemp += Time.deltaTime;
                if (timeTemp > 5) timeTemp = 0;
            }
        }
    }
}