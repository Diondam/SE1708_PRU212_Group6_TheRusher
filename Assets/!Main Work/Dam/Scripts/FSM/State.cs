namespace _Main_Work.Dam.Scripts.FSM
{
    public class State
    {
        public enum StateType
        {
            Idle,
            Walk,
            Attack,
            Die
        };

        public State( ref Entity entity, ChangeStateMachine changeStateMachine)
        {
            this.changeStateMachine = changeStateMachine;
        }

        protected ChangeStateMachine changeStateMachine;

        public virtual void OnStart()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}