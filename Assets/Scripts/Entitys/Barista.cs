using Assets.StateMachines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barista : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();


    }
}
