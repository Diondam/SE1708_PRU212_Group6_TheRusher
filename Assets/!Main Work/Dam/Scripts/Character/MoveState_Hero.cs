using _Main_Work.Dam.Scripts.FSM;

namespace _Main_Work.Dam.Scripts.Character
{
    public class MoveState_Hero: State
    {
        public MoveState_Hero(Entity entity, ChangeStateMachine changeStateMachine) : base(entity, changeStateMachine)
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