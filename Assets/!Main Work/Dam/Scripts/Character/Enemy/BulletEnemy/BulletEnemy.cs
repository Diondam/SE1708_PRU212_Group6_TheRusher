using UnityEngine;

namespace _Main_Work.Dam.Scripts.Character.Enemy.BulletEnemy
{
    public class BulletEnemy : Enemy
    {
        private Pooling dePool;
        public Transform activePosition;
        public GameObject objectToPool;
        public int amountToPool;
        public GameObject poolContainer;

        protected override void Start()
        {
            base.Start();
            dePool = gameObject.AddComponent<Pooling>();
            dePool.Init(objectToPool, amountToPool, poolContainer);
        }

        public float time;

        public void Attack()
        {
            theHero = player.GetComponent<Hero>();
            if (canAttack && currentState != dieState && theHero.currentState != theHero.dieState)
            {
                anim?.SetTrigger("attack");
                var bullet = dePool.GetActivateObject(activePosition.position);
                gm.soundController.enemySpeaker.PlayOneShot(enemySound.AttackSound);
                Invoke("DealingDamage", 0.65f);
                Invoke("CanAttack", 0.7f);
                canAttack = false;
            }
        }
    }
}