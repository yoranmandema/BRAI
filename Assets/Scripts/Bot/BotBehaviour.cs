using System;
using UnityEngine;
using UnityEngine.AI;
using Skrypt;

public class BotBehaviour : MonoBehaviour {

    public NavMeshAgent navMeshAgent;

    private SkryptBehaviour _skryptBehaviour;

    void Start() {
        _skryptBehaviour = GetComponent<SkryptBehaviour>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        _skryptBehaviour.engine.SetValue("Move", new Func<Vector3, bool>(navMeshAgent.SetDestination));
    }
}