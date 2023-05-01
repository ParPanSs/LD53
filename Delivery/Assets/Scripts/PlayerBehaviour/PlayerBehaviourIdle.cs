using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviourIdle : Player, IPlayerBehaviour
{
    public PlayerBehaviourIdle(Animator animator, Rigidbody2D rb)
    {
        Animator = animator;
        Rb = rb;
    }

    public void Enter()
    {
        Debug.Log("Enter idle Behaviour");

        Rb.velocity = new Vector2(0, 0);
        Animator.SetBool("IDLE", true);
        //StartCoroutine(DeathCoroutine());
    }

    public void Exit()
    {
        Debug.Log("Exit idle Behaviour");

        Animator.SetBool("IDLE", false);
    }

    public void Update()
    {
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
