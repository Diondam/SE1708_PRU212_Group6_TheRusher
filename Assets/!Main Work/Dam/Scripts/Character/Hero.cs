using System;
using _Main_Work.Dam.Scripts.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace _Main_Work.Dam.Scripts.Character
{
    public class Hero:Entity
    {
        public Slider slider;
        public int damage = 10;
        public float healthPoint =100;
        public Animator anim;
        private GameManager gm;

        protected override void Awake()
        {
            base.Awake();
            currentState = new IdelState_Hero(this, changeStateMachine);
            temp = healthPoint;
            gm = FindObjectOfType<GameManager>();
            anim = GetComponent<Animator>();
        }

        protected override void Update()
        {
            base.Update();
            updateUI();
            
            if (healthPoint==0)
            {
                anim.SetBool("noBlood", false);
                anim.SetTrigger("Death");
                gm.isEndGame=true;
                GetComponent<HeroKnight>().enabled = false;
            }
        }

        public float temp;
        void updateUI()
        {
            slider.value = healthPoint / temp;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            healthPoint -= 10;
        }
    }
}