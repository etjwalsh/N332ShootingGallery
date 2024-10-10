using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuState : GameBaseState
{
    //acts as this state's "start" function
    public override void EnterState(GameStateManager gameManager)
    {
        SceneManager.LoadScene("Menu");
    }

    //acts as this state's "update" function
    public override void UpdateState(GameStateManager gameManager)
    {

    }
}
