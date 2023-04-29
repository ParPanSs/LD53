using UnityEngine;

public class PlayerBehaviourIdle : IPlayerBehaviour
{
    public void Enter()
    {
        Debug.Log("Enter idle state");
    }

    public void Exit()
    {
        Debug.Log("Exit idle state");
    }

    public void Update()
    {
        Debug.Log("Update idle state");

    }
}
