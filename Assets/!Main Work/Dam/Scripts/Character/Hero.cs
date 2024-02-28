using _Main_Work.Dam.Scripts.FSM;

namespace _Main_Work.Dam.Scripts.Character
{
    public class Hero:Entity
    {
        protected override void Awake()
        {
            base.Awake();
            currentState = new IdelState_Hero(this, changeStateMachine);
        }
    }
}