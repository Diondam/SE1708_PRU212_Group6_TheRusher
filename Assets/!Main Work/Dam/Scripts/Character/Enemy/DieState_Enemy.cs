using _Main_Work.Dam.Scripts.FSM;
using UnityEngine;

namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class DieState_Enemy : State
    {
        private Enemy thisEnemy;

        public DieState_Enemy(Entity entity, ChangeStateMachine changeStateMachine) : base(entity, changeStateMachine)
        {
            thisEnemy = base.entity as Enemy;
        }

        public override void OnStart()
        {
            base.OnStart();
            thisEnemy.isDie = true;
            thisEnemy.anim?.SetBool("idle", false);
            thisEnemy.anim?.SetTrigger("die");
            thisEnemy.gm.soundController.enemySpeaker.PlayOneShot(thisEnemy.enemySound.DieSound);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            thisEnemy.anim?.SetBool("idle", false);
            thisEnemy.timeToDie -= Time.deltaTime;
            if (thisEnemy.timeToDie <= 0)
            {
                thisEnemy.Die();
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}