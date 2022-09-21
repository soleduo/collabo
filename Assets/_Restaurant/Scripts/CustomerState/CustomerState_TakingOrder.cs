public class CustomerState_TakingOrder : CustomerState
{
    private float timeInState = 0f;
    private float transitionDuration = 5f;

    public CustomerState_TakingOrder(Customer owner, IStateMachine<Customer> stateMachine) : base(owner, stateMachine)
    {
    }

    public override void OnInteract()
    {
        // do nothing
    }

    public override void StateEnter()
    {
        timeInState = 0f;
        owner.viewDebug.image.color = owner.viewDebug.state_TakingOrder;
    }

    public override void StateUpdate()
    {
        if (timeInState >= transitionDuration)
            stateMachine.SwitchState(stateMachine.state_WaitForFood);

        timeInState += UnityEngine.Time.deltaTime;
        //UnityEngine.Debug.Log("Taking order " + timeInState);

    }

    public override void StateExit()
    {
        //randomize order
        //player.addOrder

        base.StateExit();
    }
}
