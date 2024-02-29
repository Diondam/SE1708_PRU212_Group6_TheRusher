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

        private int change = 1;
        public override void OnUpdate()
        {
            count += Time.deltaTime;
            if (count < brakeTimeIdel)
            {
                change = change * -1;
                thisEnemy.anim.SetBool("move", true);
                var point = thisEnemy.transform.position;
                point.x = point.x + 2*change;
                thisEnemy.transform.Translate(point);
            }
            else
            {
                thisEnemy.anim.SetBool("idle", true);
            }

            if (count >= 2 * brakeTimeIdel)
            {
                count = 0;
                thisEnemy.Flip();
            }
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