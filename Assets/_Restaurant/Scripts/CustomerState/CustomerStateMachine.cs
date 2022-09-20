public class CustomerStateMachine : IStateMachine<Customer>
{
    private Customer owner;
    private CustomerState currentState;
    private CustomerState previousState;
    private bool enabled;

    public IState<Customer> state_WaitForOrder;
    public IState<Customer> state_TakingOrder;
    public IState<Customer> state_WaitForFood;
    public IState<Customer> state_Eating;
    public IState<Customer> state_DirtyTable;

    public CustomerState ActiveState { get { return currentState; } }

    public CustomerStateMachine(Customer owner)
    {
        SetOwner(owner);

        state_WaitForOrder = new CustomerState_WaitForOrder(owner, this);
        state_TakingOrder = new CustomerState_TakingOrder(owner, this);
        state_WaitForFood = new CustomerState_WaitForFood(owner, this);
        state_Eating = new CustomerState_Eating(owner, this);
        state_DirtyTable = new CustomerState_TableDirty(owner, this);

        SwitchState(state_WaitForOrder);


        owner.table.OnCustomerLeft += () => SetEnabled(false);
    }

    public void Update()
    {
        if (!enabled)
            return;

        if (currentState == null)
            return;

        ActiveState.StateUpdate();
    }

    public void SetEnabled(bool isEnabled)
    {
        enabled = isEnabled;
    }

    public void SetOwner(Customer owner)
    {
        this.owner = owner;
        SetEnabled(true);
    }

    public void SwitchState(IState<Customer> newState)
    {
        enabled = false;

        if (previousState != null)
        {
            if (previousState == newState)
            {
                enabled = true;
                return;
            }

            previousState = currentState;
            previousState.StateExit();
        }

        currentState = (CustomerState)newState;
        currentState.SetOwner(owner, this);
        currentState.StateEnter();

        UnityEngine.Debug.Log("State Switched " + currentState.GetType().ToString());

        enabled = true;
    }

    public void ReverseState()
    {
        if (previousState == null)
            return;

        enabled = false;

        IState<Customer> _temp = previousState;
        previousState = currentState;

        SwitchState(_temp);
    }
}
