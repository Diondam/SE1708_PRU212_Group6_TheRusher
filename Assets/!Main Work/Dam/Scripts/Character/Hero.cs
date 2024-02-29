using System;
using _Main_Work.Dam.Scripts.FSM;
using UnityEngine;

namespace _Main_Work.Dam.Scripts.Character
{
    public class Hero:Entity
    {

        public int damage = 10;
        public float healthPoint;
        protected override void Awake()
        {
            base.Awake();
            currentState = new IdelState_Hero(this, changeStateMachine);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (Input.GetMouseButtonDown(0) && other.gameObject.CompareTag("Enemy"))
            {
                
            }
        }
    }
}