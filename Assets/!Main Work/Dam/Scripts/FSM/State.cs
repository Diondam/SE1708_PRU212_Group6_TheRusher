namespace _Main_Work.Dam.Scripts.FSM
{
    public class State
    {
        protected Entity entity;
        protected ChangeStateMachine changeStateMachine;

        public State(Entity entity, ChangeStateMachine changeStateMachine)
        {
            this.changeStateMachine = changeStateMachine;
            this.entity = entity;
        }


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