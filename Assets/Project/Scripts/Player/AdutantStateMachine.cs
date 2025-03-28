using System;
using System.Collections.Generic;
using UnityEngine;

public class AdutantStateMachine : MonoBehaviour
{
    private State _currentState;
    [SerializeField] private FactoryStateAdutant _stateHelperFactory;
    private Dictionary<Type, State> _states;

    public State PrewiousState { get; private set; }

    private void Start()
    {
        _states = new Dictionary<Type, State>()
        {
            [typeof(IdleState)] = _stateHelperFactory.Create(typeof(IdleState).ToString())
        };
        StartState<IdleState>();
    }

    public void SwichToPrewious()
    {
        _currentState.Exit();
        _currentState = PrewiousState;
        _currentState.Start();
    }
    public void SwichState<T>() where T : State
    {
        PrewiousState = _currentState;
        _currentState.Exit();
        StartState<T>();
    }
    private void StartState<T>() where T : State
    {
        _currentState = _states[typeof(T)];
        _currentState.Start();
    }

    private void Update()
    {
        if (_currentState == null)
        {
            return;
        }
        _currentState.Update();
    }
}
