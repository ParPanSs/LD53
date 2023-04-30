using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<Type, IPlayerBehaviour> behavioursMap;
    private IPlayerBehaviour behaviourCurrent;
    protected Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        InitBehaviours();
        SetBehaviourByDefault();
    }

    private void InitBehaviours()
    {
        behavioursMap = new Dictionary<Type, IPlayerBehaviour>();

        behavioursMap[typeof(PlayerBehaviourHiding)] = new PlayerBehaviourHiding(_animator); 
        behavioursMap[typeof(PlayerBehaviourWalk)] = new PlayerBehaviourWalk(_animator); 
        behavioursMap[typeof(PlayerBehaviourIdle)] = new PlayerBehaviourIdle(_animator); 
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
}
