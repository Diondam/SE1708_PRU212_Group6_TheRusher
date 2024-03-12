using _Main_Work.Dam.Scripts.FSM;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class IdleState_Enemy : State
    {
        private Enemy thisEnemy;

        public float count;

        public IdleState_Enemy(Entity entity, ChangeStateMachine changeStateMachine) : base(entity, changeStateMachine)
        {
            thisEnemy = base.entity as Enemy;
        }

        public override void OnStart()
        {
            base.OnStart();
            thisEnemy.anim?.SetBool("idle", true);
            thisEnemy.canAttack = false;
            count = thisEnemy.moveRandomTime;
            startPos = thisEnemy.transform.position;
        }

        //change is only 1 or -1
        public Vector3 startPos;

        public override void OnUpdate()
        {
            base.OnUpdate();
            MoveRandom(ref thisEnemy.moveRandomTime, ref thisEnemy.rangeIdle);

            if (thisEnemy.CheckAttack() && thisEnemy.currentState != thisEnemy.attackState)
            {
                changeStateMachine.ChangeToState(thisEnemy.attackState);
            }
        }

        Vector3 point;

        private void MoveRandom(ref float brakeTimeIdel, ref float rangeIdle)
        {
            count += Time.deltaTime;
            if (count < brakeTimeIdel)
            {
                thisEnemy.anim?.SetBool("idle", false);
                thisEnemy.anim?.SetBool("move", true);
                thisEnemy.transform.position = Vector3.Lerp(startPos, point, count / brakeTimeIdel);
            }
            else
            {
                thisEnemy.anim?.SetBool("move", false);
                thisEnemy.anim?.SetBool("idle", true);
            }

            if (count >= 2 * brakeTimeIdel)
            {
                count = 0;
                thisEnemy.Flip();
                startPos = thisEnemy.transform.position;
                point = startPos;
                point.x = point.x + rangeIdle * (thisEnemy.flip ? 1 : -1);
            }
        }


        public override void OnExit()
        {
            base.OnExit();
        }
    }
}