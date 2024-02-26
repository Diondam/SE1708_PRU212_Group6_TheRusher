using UnityEngine;

namespace _Main_Work.Dam.Scripts.FSM
{
    public class Enity : MonoBehaviour
    {
        public Enity()
        {
            changeStateMachine = new ChangeStateMachine(currentState);
            currentState = new State(changeStateMachine);
        }
        State currentState;
        ChangeStateMachine changeStateMachine;

        State newState;
        public void ChangeState(State state)
        {
            currentState = changeStateMachine.ChangeToState(state);
        }
        
        void Start()
        {
            currentState.OnStart();
        }
        
        void Update()
        {
            currentState.OnUpdate();
        }
        
        void LateUpdate()
        {
            currentState.OnExit();
        }
    }
}