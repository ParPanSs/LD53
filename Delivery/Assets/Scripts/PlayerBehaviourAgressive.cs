using UnityEngine;

public class PlayerBehaviourAgressive : IPlayerBehaviour
{
    public void Enter()
    {
        Debug.Log("Enter agressive state");
    }

    public void Exit()
    {
        Debug.Log("Exit agressive state");
    }

    public void Update()
    {
        Debug.Log("Update agressive state");
    }
}
