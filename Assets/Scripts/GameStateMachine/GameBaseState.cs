using UnityEngine;

public abstract class GameBaseState
{
    public abstract void EnterState(GameStateManager gameManager);
    public abstract void UpdateState(GameStateManager gameManager);
}
