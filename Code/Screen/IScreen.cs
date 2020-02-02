public interface IScreen
{
    void Init(StateManager stateManager);
    State GetState();
}