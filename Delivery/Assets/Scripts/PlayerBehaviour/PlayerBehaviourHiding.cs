using UnityEngine;

public class PlayerBehaviourHiding : Player, IPlayerBehaviour
{
    public PlayerBehaviourHiding(Animator animator, Rigidbody2D rb, float speed, float currentHp, HealthBar health,
        GameObject button)
    {
        Animator = animator;
        Rb = rb;
        Speed = speed;
        currentHealth = currentHp;
        healthBar = health;
        restartButton = button;
    }
    public void Enter()
    {
        Speed = 10f;
        Debug.Log("Enter hiding Behaviour");
        Animator.SetBool("Hiding", true);
    }

    public void Exit()
    {
        Debug.Log("Exit hiding Behaviour");

        Animator.SetBool("Hiding", false);
        Speed = 1.5f;
    }

    public void Update()
    {
        if (currentHealth > 0)
        {
            currentHealth -= Speed * Time.deltaTime;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            restartButton.SetActive(true);
            Debug.Log("You broke the cargo");
        }
    }
}
