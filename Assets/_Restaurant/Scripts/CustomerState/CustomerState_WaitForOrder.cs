public class CustomerState_WaitForOrder : CustomerState
{
    public CustomerState_WaitForOrder(Customer owner, IStateMachine<Customer> stateMachine) : base(owner, stateMachine)
    {
    }

    public override void OnInteract()
    {
        //take order
        stateMachine.SwitchState(stateMachine.state_TakingOrder);
    }

    public override void StateEnter()
    {
        if (owner.IsTableDirty)
        {
            stateMachine.SwitchState(stateMachine.state_DirtyTable);
            return;
        }

        owner.viewDebug.image.color = owner.viewDebug.state_WaitForOrder;
    }

    public override void StateUpdate()
    {
        owner.DecayHappiness();
    }
}
