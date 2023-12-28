using Assets.Scripts.States.CustomerStates;
using Assets.StateMachines;
using Assets.States;
using System;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private StateMachine _stateMachine;

    [SerializeField] float speed = 3f;

    public bool IsGoToCoffee;
    public bool IsWaitOrder;
    public bool IsReadyToLeave;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        var customerWaitState = new CustomerWaitState(this);
        var goToCoffeeState = new GoToCoffeeState(this);
        var leaveCoffeeState = new LeaveCoffeeState(this);

        At(goToCoffeeState, customerWaitState, IsArriveCoffe());
        At(customerWaitState, leaveCoffeeState, IsCoffeeCome());
        At(leaveCoffeeState, goToCoffeeState, IsLeaveShop());

        _stateMachine.SetState(goToCoffeeState);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> IsArriveCoffe() => () => IsGoToCoffee;
        Func<bool> IsCoffeeCome() => () => IsWaitOrder;
        Func<bool> IsLeaveShop() => () => IsReadyToLeave;
    }
}