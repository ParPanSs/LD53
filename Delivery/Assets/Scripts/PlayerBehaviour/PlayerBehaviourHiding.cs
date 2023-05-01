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
        Debug.Log("Enter hiding Behaviour");
        Animator.SetBool("Hiding", true);
    }

    public void Exit()
    {
        Debug.Log("Exit hiding Behaviour");

        Animator.SetBool("Hiding", false);
    }

    public void Update()
    {
        if (currentHealth > 0)
        {
            currentHealth -= 0.05f;
            healthBar.SetHealth(currentHealth);
        }
        else if(currentHealth <= 0)
        {
            SetBehaviourIdle();
            Debug.Log("You broke the cargo");
        }
    }
}
