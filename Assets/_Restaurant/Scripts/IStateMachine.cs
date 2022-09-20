public interface IStateMachine<T>
{
    void SetOwner(T owner);
    void SetEnabled(bool isEnabled);
    void SwitchState(IState<T> newState);
}
