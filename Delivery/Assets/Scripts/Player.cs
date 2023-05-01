using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<Type, IPlayerBehaviour> behavioursMap;
    private IPlayerBehaviour behaviourCurrent;
    [SerializeField] protected Animator Animator;
    protected Rigidbody2D Rb;

    private Rigidbody2D _leftWheel;
    private Rigidbody2D _rightWheel;

    protected float Speed = 10f;
    public float maxHp = 100f;
    public float currentHealth;

    public HealthBar healthBar;
    private void Start()
    {
        currentHealth = maxHp;
        healthBar.SetMaxHealth(maxHp);
        Rb = GetComponent<Rigidbody2D>();
        //Animator = GetComponent<Animator>();
        InitBehaviours();
        SetBehaviourByDefault();
    }

    private void InitBehaviours()
    {
        behavioursMap = new Dictionary<Type, IPlayerBehaviour>();

        behavioursMap[typeof(PlayerBehaviourHiding)] = new PlayerBehaviourHiding(Animator, Rb, Speed, currentHealth, healthBar);
        behavioursMap[typeof(PlayerBehaviourWalk)] = new PlayerBehaviourWalk(Animator, Rb, Speed, currentHealth);
        behavioursMap[typeof(PlayerBehaviourIdle)] = new PlayerBehaviourIdle(Animator, Rb);
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

    private T GetBehaviour<T>() where T : IPlayerBehaviour
    {
        var type = typeof(T);
        return (T) behavioursMap[type];
    }

    private void Update()
    {
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
    }
}
