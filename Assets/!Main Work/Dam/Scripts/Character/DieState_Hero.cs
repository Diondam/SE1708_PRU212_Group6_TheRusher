using _Main_Work.Dam.Scripts.FSM;

namespace _Main_Work.Dam.Scripts.Character
{
    public class DieState_Hero: State
    {
        public DieState_Hero(Entity entity, ChangeStateMachine changeStateMachine) : base(entity, changeStateMachine)
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