using _Main_Work.Dam.Scripts.FSM;
using UnityEngine;


namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class IdleState_Enemy : State
    {
        private Enemy thisEnemy;
        public float brakeTimeIdel = 4f;
        public float count;

        public IdleState_Enemy(Entity entity, ChangeStateMachine changeStateMachine) : base(entity, changeStateMachine)
        {
            thisEnemy = base.entity as Enemy;
        }

        public override void OnStart()
        {
            base.OnStart();
            thisEnemy.anim.SetBool("idle", true);
            count = brakeTimeIdel;
        }

        public override void OnUpdate()
        {
            count += Time.deltaTime;
            if (count < brakeTimeIdel)
            {
                thisEnemy.anim.SetBool("move", true);
            }
            else
            {
                thisEnemy.anim.SetBool("idle", true);
            }
            if (count >= 2*brakeTimeIdel) count = 0;
            base.OnUpdate();
            if (thisEnemy.CheckAttack())
            {
                changeStateMachine.ChangeToState(thisEnemy.attackState);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}