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
            thisEnemy.anim?.SetTrigger("die");
        }

        public override void OnUpdate()
        {
            thisEnemy.timeToDie -= Time.deltaTime;
            if (thisEnemy.timeToDie <= 0)
            {
                thisEnemy.Die();
            }

            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}