using UnityEngine;

public class PlayerBehaviourHiding : Player, IPlayerBehaviour
{
    public PlayerBehaviourHiding(Animator animator, Rigidbody2D rb, float speed, float currentHp, HealthBar health)
    {
        Animator = animator;
        Rb = rb;
        Speed = speed;
        currentHealth = currentHp;
        healthBar = health;
    }
    public void Enter()
    {
        Animator.SetBool("Hiding", true);
    }

    public void Exit()
    {
        Animator.SetBool("Hiding", false);
    }

    public void Update()
    {
        if (currentHealth > 0)
        {
            currentHealth -= 0.01f;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            Debug.Log("You broke the cargo");
        }
    }
}
