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
        public GameObject attackEffect;
        public float offsetEffect = 0.7f;

        public DieState_Hero dieState;
        protected override void Awake()
        {
            base.Awake();
            var idleState = new IdelState_Hero(this, changeStateMachine);
            dieState = new DieState_Hero(this, changeStateMachine);
            changeStateMachine.ChangeToState(idleState);
            temp = healthPoint;
            heroController = GetComponent<HeroKnight>();
            gm = FindObjectOfType<GameManager>();
            if(gm ==null) print("gm null");
            transform.position = gm.diePoint==null? Vector3.zero : gm.diePoint;
        }

        private void Start()
        {
            print("spawn effect");
            attackEffect =Instantiate(attackEffect, transform);
        }

        protected override void Update()
        {
            base.Update();
            updateUI();

            if (healthPoint <= 0)
            {
                //play die sound
                var soundControler = gm.soundController;
                soundControler.heroSpeaker.PlayOneShot(soundControler.heroDieSound);

                changeStateMachine.ChangeToState(dieState);
                gm.diePoint = transform.position;
                GetComponent<HeroKnight>().enabled = false;
                anim.SetBool("noBlood", false);
                anim.SetTrigger("Death");
                Invoke("EndGame", 1.1f);
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                print("effect");
                attackEffect.SetActive(false);
                attackEffect.SetActive(true);
            }
        }

        void EndGame()
        {
            gm.EndGame();
        }

        public void TakeDamage(int damage)
        {
            healthPoint -= damage;
            anim.SetTrigger("Hurt");
        }
        
        private void OnTriggerEnter2D(Collider2D other)
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