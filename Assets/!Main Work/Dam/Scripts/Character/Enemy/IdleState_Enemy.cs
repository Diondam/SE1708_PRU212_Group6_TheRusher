using _Main_Work.Dam.Scripts.FSM;

namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class IdleState_Enemy:State
    {
        public IdleState_Enemy(Entity entity, ChangeStateMachine changeStateMachine) : base(entity, changeStateMachine)
        {
        }
        
        public override void OnStart()
        {
            base.OnStart();
            
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