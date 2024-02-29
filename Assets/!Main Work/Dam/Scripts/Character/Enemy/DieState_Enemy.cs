using _Main_Work.Dam.Scripts.FSM;

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
            thisEnemy.anim.SetBool("die", true);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}