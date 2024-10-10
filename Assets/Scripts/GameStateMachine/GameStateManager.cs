using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameBaseState currentState;
    public GameMenuState menuState = new GameMenuState();
    public GamePausedState pausedState = new GamePausedState();
    public GameOverState overState = new GameOverState();
    public GamePlayState playState = new GamePlayState();

    // Start is called before the first frame update
    void Start()
    {
        currentState = menuState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
