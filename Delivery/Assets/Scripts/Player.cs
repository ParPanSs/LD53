using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float Speed;

    private Dictionary<Type, IPlayerBehaviour> behavioursMap;
    private IPlayerBehaviour behaviourCurrent;
    [SerializeField] protected Animator Animator;
    protected Rigidbody2D Rb;

    [SerializeField] protected GameObject restartButton;

    [SerializeField] private GameObject finishAnimator;
    private const float MaxHp = 100f;
    public static float currentHealth;

    [SerializeField] protected HealthBar healthBar;

    public float timer;

    private void Start()
    {
        Speed = 5f;
        currentHealth = MaxHp;
        healthBar.SetMaxHealth(MaxHp);
        Rb = GetComponent<Rigidbody2D>();
        InitBehaviours();
        SetBehaviourByDefault();
    }

    private void InitBehaviours()
    {
        behavioursMap = new Dictionary<Type, IPlayerBehaviour>();

        behavioursMap[typeof(PlayerBehaviourHiding)] = new PlayerBehaviourHiding(Animator, Rb, Speed, currentHealth, healthBar, restartButton);
        behavioursMap[typeof(PlayerBehaviourWalk)] = new PlayerBehaviourWalk(Animator, Rb, Speed, currentHealth);
        behavioursMap[typeof(PlayerBehaviourIdle)] = new PlayerBehaviourIdle(Animator, Rb);
        behavioursMap[typeof(PlayerBehaviourStick)] = new PlayerBehaviourStick(Animator, Rb);
    }

    private void SetBehaviour(IPlayerBehaviour newBehaviour)
    {
        if (behaviourCurrent != null)
        {
            behaviourCurrent.Exit();
        }

        behaviourCurrent = newBehaviour;
        behaviourCurrent.Enter();
    }

    private void SetBehaviourByDefault()
    {
        SetBehaviourIdle();
    }

    private IPlayerBehaviour GetBehaviour<T>() where T : IPlayerBehaviour
    {
        var type = typeof(T);
        return behavioursMap[type];
    }

    private void Update()
    {
        UpdateTimer();
        Debug.Log(Speed);
        if(behaviourCurrent != null)
            behaviourCurrent.Update();
    }

    public void SetBehaviourIdle()
    {
        var behaviour = GetBehaviour<PlayerBehaviourIdle>();
        SetBehaviour(behaviour);
    }

    public void SetBehaviourHiding()
    {
        var behaviour = GetBehaviour<PlayerBehaviourHiding>();
        SetBehaviour(behaviour);
    }

    public void SetBehaviourWalk()
    {
        var behaviour = GetBehaviour<PlayerBehaviourWalk>();
        SetBehaviour(behaviour);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        float seconds = Mathf.FloorToInt(timer % 60);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("DETECTED");
        if (col.CompareTag("Walk"))
        {
            SetBehaviourWalk();
        }
        if (col.CompareTag("Hiding"))
        {
            SetBehaviourHiding();
        }
        if (col.CompareTag("IDLE"))
        {
            SetBehaviourIdle();
        }

        if (col.CompareTag("Finish"))
        {
            finishAnimator.SetActive(true);
            this.enabled = false;
        }

        if (col.CompareTag("Sticky"))
        {
            restartButton.SetActive(true);
        }
    }
}
