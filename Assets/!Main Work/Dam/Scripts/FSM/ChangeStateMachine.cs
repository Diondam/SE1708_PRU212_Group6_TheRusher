namespace _Main_Work.Dam.Scripts.FSM
{
    public class ChangeStateMachine
    {
        public ChangeStateMachine(ref State state)
        {
            currentState = state;
        }
     
        State currentState;
      
        public State ChangeToState(State state)
        {
            currentState?.OnExit();
            currentState = state;
            state.OnStart();
            return state;
        }
    }
}