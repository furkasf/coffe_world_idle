using Assets.Scripts.Entitys;
using Assets.Scripts.States.BaristaStates;
using Assets.StateMachines;
using Assets.States;
using System;
using UnityEngine;

public class Barista : MonoBehaviour
{
    private StateMachine _stateMachine;

    [SerializeField] Transform _coffeMachine;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] float speed = 3f;

    public Transform CoffeMachineTrans => _coffeMachine;
    public Node BaristaNode;
    public bool IsOrdertaken;
    public bool IsCoffeePrepared;
    public bool IsCoffeeDelivered;

    public Vector3 BaristaPos => transform.position;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        WaitOrderState waitOrder = new WaitOrderState(this);
        GetOrderState getOrder = new GetOrderState(this, _spriteRenderer);
        PrepareOrderState prepareOrder = new PrepareOrderState(this, _spriteRenderer);
        DelivareOrderState delivareOrder = new DelivareOrderState(this);

        At(waitOrder, getOrder, OnIsWait());
        At(getOrder, prepareOrder, OnIsOrderTaken());
        At(prepareOrder, delivareOrder, OnIsCoffeePrepared());
        At(delivareOrder, waitOrder, OnCoffeeDelivered());

        _stateMachine.SetState(waitOrder);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> OnIsWait() => () => BaristaNode != null;
        Func<bool> OnIsOrderTaken() => () => IsOrdertaken;
        Func<bool> OnIsCoffeePrepared() => () => IsCoffeePrepared;
        Func<bool> OnCoffeeDelivered() => () => IsCoffeeDelivered;
    }

    private void Update()
    {
        _stateMachine?.Tick();
    }
}