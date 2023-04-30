using UnityEngine;

public class PlayerBehaviourIdle : Player, IPlayerBehaviour
{
    public PlayerBehaviourIdle(Animator animator)
    {
        _animator = animator;
    }

    public void Enter()
    {
        _animator.SetBool("IDLE", true);
        Debug.Log("Enter idle state");
    }

    public void Exit()
    {
        _animator.SetBool("IDLE", false);
        Debug.Log("Exit idle state");
    }

    public void Update()
    {
        Debug.Log("Update idle state");
    }
}
