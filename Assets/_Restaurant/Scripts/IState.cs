public interface IState<T>
{
    void SetOwner(T owner, IStateMachine<T> stateMachine);
    void StateEnter();
    void StateUpdate();
    void StateExit();
}
