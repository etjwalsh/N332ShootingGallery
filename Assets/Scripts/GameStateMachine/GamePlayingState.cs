using UnityEngine;

public class GamePlayState : GameBaseState
{
    //acts as this state's "start" function
    public override void EnterState(GameStateManager gameManager)
    {
        GameObject.Instantiate(gameManager.ResetTrigger, new Vector3(0, 0, 0), Quaternion.identity);
    }

    //acts as this state's "update" function
    public override void UpdateState(GameStateManager gameManager)
    {

    }
}
