using _Main_Work.Dam.Scripts.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class Enemy : Entity
    {
        public Animator anim = null;
        public GameObject effect;
        public float offsetEffect = 0.5f;
        public GameManager gm;
        public GameObject player;
        protected Hero theHero;

        [Header("Idel")] public float moveRandomTime = 4;
        public float rangeIdle = 1;

        [Header("Health")] public int damage = 2;
        public int healthPoint = 100;
        public int healthPointTemp;
        public float timeToDie = 0.9f;
        public Slider slider;

        [Header("Attack")] public float attackRange = 2f;
        public float chaseRange = 5;
        public float speedToAttack = 1;
        public bool canAttack = false;
        public bool flip = false;

        [Header("Sound Data")] public SoundData enemySound;

        public IdleState_Enemy idelState { get; private set; }
        public AttackState_Enemy attackState { get; private set; }
        public DieState_Enemy dieState { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            idelState = new IdleState_Enemy(this, changeStateMachine);
            attackState = new AttackState_Enemy(this, changeStateMachine);
            dieState = new DieState_Enemy(this, changeStateMachine);

            anim = GetComponent<Animator>() ?? null;
            changeStateMachine.ChangeToState(idelState);
            player = GameObject.FindGameObjectWithTag("Player");
            gm = FindObjectOfType<GameManager>();
            print("Enemy Awake");
        }

        protected virtual void Start()
        {
            if (flip)
            {
                var localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
                FlipSlider();
            }

            healthPointTemp = healthPoint;
            effect = Instantiate(effect, transform);
            chaseRange = attackRange;
            tempPos1 = transform.position.x + attackRange;
            tempPos2 = transform.position.x - attackRange;
        }

        private float tempPos1;
        private float tempPos2;

        protected override void Update()
        {
            base.Update();
            UpdateUI();
            ConvincePos();
        }

        void UpdateUI()
        {
            slider.value = (float)healthPoint / healthPointTemp;
        }

        public bool CheckAttack()
        {
            float distace = Vector2.Distance(transform.position, player.transform.position);
            return distace <= attackRange;
        }

        public bool CheckChase()
        {
            float distace = Vector2.Distance(transform.position, player.transform.position);
            return distace <= chaseRange;
        }

        bool touched = false;
        protected Vector3 directionE;

        public bool CheckMove()
        {
            //nằm ngoài
            return (transform.position.x > tempPos1 || transform.position.x < tempPos2);
        }

        public void ConvincePos()
        {
            var pos = transform.position;
            if (pos.x > tempPos1)
            {
                Vector3 tempPos = new Vector3(pos.x - convinceAmount, pos.y, pos.z);
                transform.position = tempPos;
            }

            if (pos.x < tempPos2)
            {
                Vector3 tempPos = new Vector3(pos.x + convinceAmount, pos.y, pos.z);
                transform.position = tempPos;
            }
        }

        public float convinceAmount = 0.08f;

        public void MoveToPlayer()
        {
            var direction = (player.transform.position - transform.position).normalized;
            directionE = direction;
            direction.y = 0;
            if (!touched && !CheckMove())
            {
                transform.Translate(direction * (speedToAttack * Time.deltaTime));
                print("move to player");
                ConvincePos();
            }

            //flip by direction
            var localScale = transform.localScale;

            if (direction.x < 0)
            {
                localScale.x = -1 * Mathf.Abs(localScale.x);
                if (!f)
                {
                    print("left");
                    FlipSlider();
                    f = true;
                }
            }
            else if (direction.x > 0)
            {
                localScale.x = 1 * Mathf.Abs(localScale.x);
                if (f)
                {
                    print("right");
                    FlipSlider();
                    f = false;
                }
            }

            transform.localScale = localScale;
        }

        bool f = false;

        public void Flip()
        {
            var localScale = transform.localScale;
            localScale.x = localScale.x * -1;
            transform.localScale = localScale;
            FlipSlider();
        }

        void FlipSlider()
        {
            var sliderScale = slider.transform.localScale;
            sliderScale.x = sliderScale.x * -1;
            slider.transform.localScale = sliderScale;
        }

        public void Die()
        {
            Destroy(gameObject);
        }


        public void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                touched = true;
                isOKforDame = true;
                Attack();
                if (Input.GetMouseButtonDown(0))
                {
                    print("click");
                    healthPoint -= theHero.damage;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                isOKforDame = true;
                Attack();
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            touched = false;
            isOKforDame = false;
        }

        bool isOKforDame = false;
        public bool isDie = false;

        void Attack()
        {
            if (canAttack && currentState != dieState)
            {
                theHero = player.GetComponent<Hero>();
                anim?.SetTrigger("attack");
                gm.soundController.enemySpeaker.PlayOneShot(enemySound.AttackSound);
                Invoke("DealingDamage", 0.65f);
                Invoke("CanAttack", 0.7f);
                canAttack = false;
            }
        }

        void CanAttack()
        {
            canAttack = true;
        }


        void DealingDamage()
        {
            if (isOKforDame)
            {
                SpawnAttackEffect();
                theHero.TakeDamage(damage);
            }
        }

        void SpawnAttackEffect()
        {
            Vector3 spawnPosition;
            spawnPosition = (Vector3.right * (flip ? -1 : 1) + Vector3.up) * offsetEffect;
            if (spawnPosition.y < 0) spawnPosition.y = spawnPosition.y * -1;
            effect.transform.localPosition = spawnPosition;
            effect.SetActive(false);
            effect.SetActive(true);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(this.transform.position, chaseRange);

            var temp = new Vector3(tempPos1, 0, 0);
            var temppp = new Vector3(tempPos2, 0, 0);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(temp, temp + Vector3.up * 5);
            Gizmos.DrawLine(temppp, temppp + Vector3.up * 5);
        }
    }
}