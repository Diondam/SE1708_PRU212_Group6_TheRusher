using _Main_Work.Dam.Scripts.FSM;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class IdleState_Enemy : State
    {
        private Enemy thisEnemy;

        //public float brakeTimeIdel = 4f;
        public float count;

        public IdleState_Enemy(Entity entity, ChangeStateMachine changeStateMachine) : base(entity, changeStateMachine)
        {
            thisEnemy = base.entity as Enemy;
        }

        public override void OnStart()
        {
            base.OnStart();
            thisEnemy.anim.SetBool("idle", true);
            count = thisEnemy.brakeTime;
            startPos = thisEnemy.transform.position;
            Debug.Log($"vị trí ban đầu: {startPos}");
        }
        
        //change is only 1 or -1
        private int change = -1;
        public Vector3 startPos;

        public override void OnUpdate()
        {
            base.OnUpdate();
            MoveRandom(ref thisEnemy.brakeTime);
            if (thisEnemy.CheckAttack())
            {
                changeStateMachine.ChangeToState(thisEnemy.attackState);
            }
        }

        Vector3 point;
        private void MoveRandom(ref float brakeTimeIdel)
        {
            Debug.Log($"braketime: {brakeTimeIdel} and count: {count}");
            count += Time.deltaTime;
            if (count < brakeTimeIdel)
            {
                thisEnemy.anim.SetBool("move", true);
                Debug.Log($"vị trí random: {point}");
                thisEnemy.transform.position = Vector3.Lerp(startPos, point, count / brakeTimeIdel);
            }
            else
            {
                thisEnemy.anim.SetBool("idle", true);
            }

            if (count >= 2 * brakeTimeIdel)
            {
                count = 0;
                thisEnemy.Flip();
                change = change * -1;
                startPos = thisEnemy.transform.position;
                point = startPos;
                point.x = point.x + 2 * change;
            }
        }


        public override void OnExit()
        {
            base.OnExit();
        }
    }
}