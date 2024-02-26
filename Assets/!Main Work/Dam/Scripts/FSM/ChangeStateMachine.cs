namespace _Main_Work.Dam.Scripts.FSM
{
    public class ChangeStateMachine
    {
        public ChangeStateMachine(State state)
        {
            currentState = state;
        }
     
        State currentState;
        /// <summary>
        /// truyen new state con vao day
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public State ChangeToState(State state)
        {
            
            currentState = state;

            return currentState;
        }
    }
}