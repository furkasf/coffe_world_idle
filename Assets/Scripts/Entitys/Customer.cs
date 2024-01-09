using Assets.Scripts.Entitys;
using Assets.Scripts.States.CustomerStates;
using Assets.StateMachines;
using Assets.States;
using System;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private StateMachine _stateMachine;
    private CustomerWaitState customerWaitState; 
    private GoToCoffeeState goToCoffeeState;
    private LeaveCoffeeState leaveCoffeeState;

    [SerializeField] float speed = 3f;

    public Transform SpawnPoint;
    public GameObject CoffeeSprite;
    public Node CustomerNode;
    public bool IsGoToCoffee;
    public bool IsWaitOrder;
    public bool IsReadyToLeave;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        goToCoffeeState = new GoToCoffeeState(this);
        customerWaitState = new CustomerWaitState(this);
        leaveCoffeeState = new LeaveCoffeeState(this);

        At(goToCoffeeState, customerWaitState, IsArriveCoffe());
        At(customerWaitState, leaveCoffeeState, IsCoffeeCome());

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> IsArriveCoffe() => () => IsGoToCoffee;//is realy  need that state ?
        Func<bool> IsCoffeeCome() => () => IsReadyToLeave;
    }

    private void Update()
    {
        _stateMachine?.Tick();
    }

    public void RestartStateMachine()
    {
        CustomerNode = null;
        IsGoToCoffee = false;
        IsReadyToLeave = false;
        IsWaitOrder = false;

        _stateMachine?.SetState(goToCoffeeState);
    }

    public void DeliveryTaken()
    {
        IsReadyToLeave = true;
        IsWaitOrder = false;

        CustomerNode = null;
    }
}