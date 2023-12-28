using Assets.Scripts.States.BaristaStates;
using Assets.StateMachines;
using Assets.States;
using System;
using UnityEngine;

public class Barista : MonoBehaviour
{
    private StateMachine _stateMachine;

    [SerializeField] float speed = 3f;

    public bool IsCustomerCome;
    public bool IsOrdertaken;
    public bool IsCoffeePrepared;
    public bool IsCoffeeDelivered;

    public Vector3 BaristaPos => transform.position;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        WaitOrderState waitOrder = new WaitOrderState(this);
        GetOrderState getOrder = new GetOrderState(this);
        PrepareOrderState prepareOrder = new PrepareOrderState(this);
        DelivareOrderState delivareOrder = new DelivareOrderState(this);

        At(waitOrder, getOrder, OnIsWait());
        At(getOrder, prepareOrder,OnIsOrderTaken());
        At(prepareOrder, delivareOrder, OnIsCoffeePrepared());
        At(delivareOrder, waitOrder, OnCoffeeDelivered());

        _stateMachine.SetState(waitOrder);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> OnIsWait() => () => IsCustomerCome;
        Func<bool> OnIsOrderTaken() => () => IsOrdertaken;
        Func<bool> OnIsCoffeePrepared() => () => IsCoffeePrepared;
        Func<bool> OnCoffeeDelivered() => () => IsCoffeeDelivered;
    }
}