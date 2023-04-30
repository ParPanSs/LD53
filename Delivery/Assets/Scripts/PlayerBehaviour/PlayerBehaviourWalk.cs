using UnityEngine;

public class PlayerBehaviourWalk : Player, IPlayerBehaviour
{
    public PlayerBehaviourWalk(Animator animator)
    {
        _animator = animator;
    }
    public void Enter()
    {
        _animator.SetBool("Walk", true);
        Debug.Log("Enter walk state");
    }

    public void Exit()
    {
        _animator.SetBool("Walk", false);
        Debug.Log("Exit walk state");
    }

    public void Update()
    {
        Debug.Log("Update walk state");
    }
}
