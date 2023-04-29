using UnityEngine;

public class PlayerBehaviourActive : IPlayerBehaviour
{
    public void Enter()
    {
        Debug.Log("Enter active state");
    }

    public void Exit()
    {
        Debug.Log("Exit active state");
    }

    public void Update()
    {
        Debug.Log("Update active state");

    }
}
