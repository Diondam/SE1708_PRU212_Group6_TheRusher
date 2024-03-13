using _Main_Work.Dam.Scripts.FSM;
using UnityEngine;

namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class AttackState_Enemy : State
    {
        private Enemy thisEnemy;

        public AttackState_Enemy(Entity entity, ChangeStateMachine changeStateMachine) : base(entity,
            changeStateMachine)
        {
            thisEnemy = base.entity as Enemy;
        }

        public override void OnStart()
        {
            base.OnStart();
            
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            thisEnemy.MoveToPlayer();
            if (thisEnemy is BulletEnemy.BulletEnemy bulletEnemy)
            {
                bulletEnemy?.Attack();
            }
            var hero = thisEnemy.player.GetComponent<Hero>();
            //đánh chết player
            if (hero.healthPoint <= 0 && thisEnemy.currentState == thisEnemy.attackState)
            {
                changeStateMachine.ChangeToState(thisEnemy.idelState);
            }

            //bị player đánh chết
            if (thisEnemy.healthPoint <= 0 && thisEnemy.currentState != thisEnemy.dieState)
            {
                changeStateMachine.ChangeToState(thisEnemy.dieState);
            }

            if(!thisEnemy.CheckChase() && thisEnemy.currentState == thisEnemy.attackState)
            {
                changeStateMachine.ChangeToState(thisEnemy.idelState);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}