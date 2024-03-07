using System;
using _Main_Work.Dam.Scripts.FSM;
using UnityEngine;

namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class Enemy:Entity
    {
        public Animator anim;
        public GameObject effect;
        public float attackRange = 2.5f;
        public GameObject player;
        public float moveSpeed;
        public float healthPoint;
        public float brakeTime =4;
        public int damage = 2;
        //public GameObject dieEffect;
        
        public IdleState_Enemy idelState { get; private set; }
        public AttackState_Enemy attackState { get; private set; }
        public DieState_Enemy dieState{ get; private set; }
        protected override void Awake()
        {           
            idelState = new IdleState_Enemy(this, changeStateMachine);
            attackState = new AttackState_Enemy(this, changeStateMachine);
            dieState = new DieState_Enemy(this, changeStateMachine);
            currentState = idelState;
            player = GameObject.FindGameObjectWithTag("Player");
            anim = GetComponent<Animator>();
            print("Enemy Awake");
            base.Awake();
            changeStateMachine.ChangeToState(idelState);
        }

        public bool CheckAttack()
        {
            float distace = Vector2.Distance(transform.position, player.transform.position);
            return attackRange > distace;
        }


        public void MoveToPlayer()
        {
            var direction = player.transform.position - transform.position;
            transform.Translate((Vector2)direction.normalized * moveSpeed * Time.deltaTime);
            
        }

        public void Flip()
        {
            var localScale = transform.localScale;
            localScale.x = localScale.x*-1;
            transform.localScale = localScale;
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var theHero = player.GetComponent<Hero>();
                anim.SetBool("attack", true);
                theHero.healthPoint -= damage;
                if (Input.GetMouseButtonDown(0))
                {
                    healthPoint -= theHero.damage;
                }
            }
        }
    }
}