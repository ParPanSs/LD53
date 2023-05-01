using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<Type, IPlayerBehaviour> behavioursMap;
    private IPlayerBehaviour behaviourCurrent;
    [SerializeField] protected Animator Animator;
    protected Rigidbody2D Rb;

    protected float Speed = 5f;
    private float _acceleration = 10f;
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

    private IPlayerBehaviour GetBehaviour<T>() where T : IPlayerBehaviour
    {
        var type = typeof(T);
        //if(behavioursMap != null)
        return behavioursMap?[type];
        // else
        // {
        //     InitBehaviours();
        // }
        //
        // return (T) behaviourCurrent;
    }

    private void Update()
    {
        if(behaviourCurrent != null)
            behaviourCurrent.Update();
    }

    private void FixedUpdate()
    {
        // Rb.velocity += (Vector2)transform.forward * _acceleration * Time.fixedDeltaTime;
        // Rb.velocity = Vector3.ClampMagnitude(Rb.velocity, Speed);
        // transform.Translate(Rb.velocity * Time.fixedDeltaTime, Space.World);
        
        // Vector3 movement = Vector3.forward; // движение вправо
        // movement = movement.normalized * _acceleration; // нормализация вектора и умножение на значение ускорения
        // Rb.AddForce(movement, ForceMode2D.Force); // добавление силы к телу
        var step = .5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transform.position, step);
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
        if (col.CompareTag("Hiding") && currentHealth > 0)
        {
            SetBehaviourHiding();
        }
        if (col.CompareTag("IDLE"))
        {
            SetBehaviourIdle();
        }
    }
}
