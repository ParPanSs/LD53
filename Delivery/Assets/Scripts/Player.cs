using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Dictionary<Type, IPlayerBehaviour> behavioursMap;
    private IPlayerBehaviour behaviourCurrent;

    private void Start()
    {
        InitBehavours();
        SetBehaviourByDefault();
    }

    private void InitBehavours()
    {
        behavioursMap = new Dictionary<Type, IPlayerBehaviour>();

        behavioursMap[typeof(PlayerBehaviourActive)] = new PlayerBehaviourActive(); 
        behavioursMap[typeof(PlayerBehaviourAgressive)] = new PlayerBehaviourAgressive(); 
        behavioursMap[typeof(PlayerBehaviourIdle)] = new PlayerBehaviourIdle(); 
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

    public void SetBehaviourAgressive()
    {
        var behaviour = GetBehaviour<PlayerBehaviourAgressive>();
        SetBehaviour(behaviour);
    }

    public void SetBehaviourActive()
    {
        var behaviour = GetBehaviour<PlayerBehaviourActive>();
        SetBehaviour(behaviour);
    }
}
