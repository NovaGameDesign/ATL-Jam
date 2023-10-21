using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;

    public TaskGoToTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if (Vector3.Distance(_transform.position, target.position) > 1.5f)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, target.position + new Vector3(0,1,0), EnemyBT.speed * Time.deltaTime);
            _transform.LookAt(target.position + new Vector3(0, 1, 0));
        }

        state = NodeState.RUNNING;
        return state;
    }

}