using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Main_Work.Dam.Scripts.FSM
{
    public class Entity : MonoBehaviour
    {
        State currentState;
        List<State> states;
        ChangeStateMachine changeStateMachine;
        State newState;

        public Entity()
        {
            if(instance == null)
            {
                instance = this;
            }
            changeStateMachine = new ChangeStateMachine(ref currentState);
        }

        public Entity instance;

        void Awake()
        {
            currentState = new State( ref instance, changeStateMachine);
        }

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