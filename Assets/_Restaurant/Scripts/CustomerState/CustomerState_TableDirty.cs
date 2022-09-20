public class CustomerState_TableDirty : CustomerState
{
    public CustomerState_TableDirty(Customer owner, IStateMachine<Customer> stateMachine) : base(owner, stateMachine)
    {
    }

    public override void OnInteract()
    {
        // clean table
    }

    public override void StateEnter()
    {
        owner.viewDebug.image.color = owner.viewDebug.state_TableDirty;

        owner.RemoveHappiness();
    }

    public override void StateUpdate()
    {
        if(!owner.IsTableDirty)
        {
            stateMachine.ReverseState();
        }

        owner.DecayHappiness();
    }
}
