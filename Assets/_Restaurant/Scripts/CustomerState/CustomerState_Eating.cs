public class CustomerState_Eating : CustomerState
{
    private float timeInState = 0f;
    private float transitionDuration = 5f;

    public CustomerState_Eating(Customer owner, IStateMachine<Customer> stateMachine) : base(owner, stateMachine)
    {
    }

    public override void OnInteract()
    {
        // do nothing
    }

    public override void StateEnter()
    {
        timeInState = 0f;
        owner.viewDebug.image.color = owner.viewDebug.state_Eating;

    }

    public override void StateUpdate()
    {
        if(timeInState >= transitionDuration)
        {
            //customer leave;
            owner.table.RemoveCustomer();
            return;
        }

        timeInState += UnityEngine.Time.deltaTime;
    }

    public override void StateExit()
    {
        timeInState = 0f;
        base.StateExit();

    }
}
