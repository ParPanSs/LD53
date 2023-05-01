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
        Debug.Log("Enter walk Behaviour");

        Animator.SetBool("Walk", true);
    }

    public void Exit()
    {
        Debug.Log("Exit walk Behaviour");
        Animator.SetBool("Walk", false);
    }

    public void Update()
    {
    }
}
