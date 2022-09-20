public class CustomerState_WaitForFood : CustomerState 
{
    public CustomerState_WaitForFood(Customer owner, IStateMachine<Customer> stateMachine) : base(owner, stateMachine)
    {
    }

    public override void OnInteract()
    {
        // give food when holding food
        stateMachine.SwitchState(stateMachine.state_Eating);
    }

    public override void StateEnter()
    {
        owner.viewDebug.image.color = owner.viewDebug.state_WaitForFood;
    }


    public override void StateUpdate()
    {
        owner.DecayHappiness();
    }
}
