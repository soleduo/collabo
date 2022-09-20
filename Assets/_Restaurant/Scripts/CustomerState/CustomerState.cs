using UnityEngine;

public abstract class CustomerState : IState<Customer>, IInteractible
{
    protected Customer owner;
    protected CustomerStateMachine stateMachine;

    public CustomerState(Customer owner, IStateMachine<Customer> stateMachine)
    {
        SetOwner(owner, stateMachine);
    }

    public void SetOwner(Customer owner, IStateMachine<Customer> stateMachine)
    {
        this.owner = owner;
        this.stateMachine = (CustomerStateMachine)stateMachine;
    }

    public virtual void StateEnter()
    {
        if (owner == null)
        {
            Debug.LogWarning("Owner has not been set. Please use SetOwner before calling StateEnter");
            return;
        }
    }

    public virtual void StateExit()
    {
        owner.AddHappiness();
    }

    public abstract void StateUpdate();

    public abstract void OnInteract();
}
