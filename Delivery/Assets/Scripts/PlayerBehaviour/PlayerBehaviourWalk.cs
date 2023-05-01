using UnityEngine;

public class PlayerBehaviourWalk : Player, IPlayerBehaviour
{
    public PlayerBehaviourWalk(Animator animator, Rigidbody2D rb, float speed, float hp)
    { 
        Animator = animator;
        Rb = rb;
        Speed = speed;
        currentHealth = hp;
    }
    public void Enter()
    {
        Animator.SetBool("Walk", true);
    }

    public void Exit()
    {
        Animator.SetBool("Walk", false);
    }

    public void Update()
    {
    }
}
