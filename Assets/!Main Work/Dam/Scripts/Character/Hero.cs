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
        public int healthPoint =100;
        public Animator anim;
        private GameManager gm;
        public HeroKnight heroController;

        protected override void Awake()
        {
            base.Awake();
            var idleState = new IdelState_Hero(this, changeStateMachine);
            currentState= changeStateMachine.ChangeToState(idleState);
            temp = healthPoint;
            gm = FindObjectOfType<GameManager>();
            heroController = GetComponent<HeroKnight>();
        }

        protected override void Update()
        {
            base.Update();
            updateUI();
            
            if (healthPoint<=0)
            {
                GetComponent<HeroKnight>().enabled = false;
                anim.SetBool("noBlood", false);
                anim.SetTrigger("Death");
                Invoke("EndGame", 3f);
            }
        }

        void EndGame()
        {
            gm.isEndGame=true;
        }

        public float temp;
        void updateUI()
        {
            slider.value = healthPoint / temp;
        }
       
    }
}