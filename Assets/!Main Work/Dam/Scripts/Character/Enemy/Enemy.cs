using System;
using _Main_Work.Dam.Scripts.FSM;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class Enemy : Entity
    {
        public Animator anim;
        public GameObject effect;
        public GameObject player;
        public float attackRange = 2.5f;
        public float speedToAttack = 0.01f;
        public int healthPoint = 100;
        public float moveRandomTime = 4;
        public float rangeIdle = 2;
        public int damage = 2;
        public float timeToDie = 1;
        public float chaseRange = 5;
        public Slider slider;
        //public GameObject dieEffect;

        public IdleState_Enemy idelState { get; private set; }
        public AttackState_Enemy attackState { get; private set; }
        public DieState_Enemy dieState { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            idelState = new IdleState_Enemy(this, changeStateMachine);
            attackState = new AttackState_Enemy(this, changeStateMachine);
            dieState = new DieState_Enemy(this, changeStateMachine);

            anim = GetComponent<Animator>();
            changeStateMachine.ChangeToState(idelState);
            player = GameObject.FindGameObjectWithTag("Player");
            print("Enemy Awake");
        }

        private void Start()
        {
            healthPointTemp = healthPoint;
        }

        public int healthPointTemp;

        protected override void Update()
        {
            
            base.Update();
            UpdateUI();
        }
     
        void UpdateUI()
        {
            slider.value =(float) healthPoint/healthPointTemp;
        }

        public bool CheckAttack()
        {
            float distace = Vector2.Distance(transform.position, player.transform.position);
            //print($"distance: {distace}");
            return distace <= attackRange;
        }

        public bool CheckChase()
        {
            float distace = Vector2.Distance(transform.position, player.transform.position);
            return distace <= chaseRange;
        }


        public void MoveToPlayer()
        {
            var direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * (speedToAttack * Time.deltaTime));
            print("moving to player");

            //flip by direction
            var localScale = transform.localScale;
            if (direction.x > 0)
            {
                localScale.x = -1;
            }
            else if (direction.x < 0)
            {
                localScale.x = 1;
            }

            transform.localScale = localScale;
        }

        public void Flip()
        {
            var localScale = transform.localScale;
            localScale.x = localScale.x * -1;
            transform.localScale = localScale;
            
        }

        public void Die()
        {
            
            Destroy(gameObject);
        }

        public bool attacking = false;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Attack();
            }
        }

        void Attack()
        {
            theHero = player.GetComponent<Hero>();
            if (!attacking)
            {
                anim.SetTrigger("attack");
                Invoke("DealingDamage", 0.65f);
                Invoke("CanAttack", 0.7f);
                attacking = true;
            }
        }

        void CanAttack()
        {
            attacking = false;
        }

        public void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Attack();
                if (Input.GetMouseButtonDown(0))
                {
                    healthPoint -= theHero.damage;
                }
            }
        }

        private Hero theHero;

        void DealingDamage()
        {
            theHero.healthPoint -= damage;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(this.transform.position, chaseRange);
        }
    }
}