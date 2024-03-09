namespace _Main_Work.Dam.Scripts.FSM
{
    public class ChangeStateMachine
    {
        private Entity _entity;
        public ChangeStateMachine(Entity entity, State state)
        {
            _entity = entity;
            _entity.currentState = state;
        }

        public ChangeStateMachine()
        {
        }

            State currentState;

        public State ChangeToState(State state)
        {
            _entity.currentState?.OnExit();
            _entity.currentState = state;
            _entity.currentState.OnStart();
            return _entity.currentState;
        }
    }
}