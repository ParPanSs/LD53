using UnityEngine;

public class PlayerBehaviourHiding : Player, IPlayerBehaviour
{
    public PlayerBehaviourHiding(Animator animator)
    {
        _animator = animator;
    }
    public void Enter()
    {
        _animator.SetBool("Hiding", true);
        Debug.Log("Enter hiding state");
    }

    public void Exit()
    {
        _animator.SetBool("Hiding", false);
        Debug.Log("Exit hiding state");
    }

    public void Update()
    {
        Debug.Log("Update hiding state");
    }
}
