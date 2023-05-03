using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Play()
    {
        StartCoroutine(LoadGame());
    }

    public void Exit()
    {
        animator.SetBool("isFade", true);
        float timer = Time.deltaTime;
        Application.Quit();
    }

    IEnumerator LoadGame()
    {
        animator.SetBool("isFade", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
