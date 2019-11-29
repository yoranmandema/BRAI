using System;
using UnityEngine;
using UnityEngine.AI;
using Skrypt;

public class BotBehaviour : MonoBehaviour {

    public bool d;
    public NavMeshAgent navMeshAgent;
    public LayerMask layerMask;

    private SkryptBehaviour _skryptBehaviour;

    void Start() {
        _skryptBehaviour = GetComponent<SkryptBehaviour>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        _skryptBehaviour.engine.SetValue("Move", new Func<Vector3, bool>(navMeshAgent.SetDestination));
        _skryptBehaviour.engine.SetValue("Raycast", new Func<Vector3, RaycastHit>(Raycast));
    }

    public RaycastHit Raycast (Vector3 end) {
        var start = transform.position;

        if (d)
            Debug.DrawLine(start,start + end, Color.red, 10f);

        Physics.Raycast(start, start + end, out RaycastHit hit, float.PositiveInfinity, layerMask);

        return hit;
    }
}