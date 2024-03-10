using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Main_Work.Dam.Scripts.FSM
{
    public class Entity : MonoBehaviour
    {
        public State currentState;
        protected ChangeStateMachine changeStateMachine;

        protected virtual void Awake()
        {
            changeStateMachine = new ChangeStateMachine(this, currentState);
        }

        protected virtual void Update()
        {
            currentState.OnUpdate();
        }
    }
}