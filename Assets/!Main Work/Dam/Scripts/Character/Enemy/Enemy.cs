using _Main_Work.Dam.Scripts.FSM;

namespace _Main_Work.Dam.Scripts.Character.Enemy
{
    public class Enemy:Entity
    {
        protected override void Awake()
        {
            base.Awake();
            currentState = new IdleState_Enemy(this, changeStateMachine);
        }
    }
}