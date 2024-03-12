using System;
using System.Collections;
using _Main_Work.Dam.Scripts.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace _Main_Work.Dam.Scripts.Character
{
    public class Hero : Entity
    {
        public Slider slider;
        public int damage = 10;
        public int healthPoint = 100;
        public Animator anim;
        private GameManager gm;
        public HeroKnight heroController;

        protected override void Awake()
        {
            base.Awake();
            var idleState = new IdelState_Hero(this, changeStateMachine);
            currentState = changeStateMachine.ChangeToState(idleState);
            temp = healthPoint;
            gm = FindObjectOfType<GameManager>();
            heroController = GetComponent<HeroKnight>();
            if(gm.diePoint != null)
            transform.position = gm.diePoint.position;
        }

        protected override void Update()
        {
            base.Update();
            updateUI();

            if (healthPoint <= 0)
            {
                var soundControler = gm.soundController;
                soundControler.heroSpeaker.PlayOneShot(soundControler.heroDieSound);
                
                GetComponent<HeroKnight>().enabled = false;
                anim.SetBool("noBlood", false);
                anim.SetTrigger("Death");
                Invoke("EndGame", 3f);
            }
        }

        void EndGame()
        {
            gm.EndGame();
        }

        private void  OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("DiePoint"))
            {
                print("Enter DiePoint");
                //gm.diePoint = transform;
                StartCoroutine("DestroyPoint", other.gameObject);
            }
        }

        IEnumerator DestroyPoint(GameObject other)
        {
            Destroy(other);
            yield return new WaitForSeconds(0.2f);
        }

        public float temp;

        void updateUI()
        {
            slider.value = healthPoint / temp;
        }
    }
}