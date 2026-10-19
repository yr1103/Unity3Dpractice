using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

/// <summary>
/// 기본적으로 생성되어 있는 거 건드리면 안됨
/// </summary>
[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Chase", story: "Chase [Target] at [Speed]", category: "Enemy", id: "20730ea837b1b2e4834f69622737f69c")]
public partial class ChaseAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<float> Speed;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {

        Transform self = GameObject.transform;
        Transform target = this.Target.Value.transform;
        Vector3 toTarget = target.position - self.position;
        
        self.LookAt(target);
        self.position += toTarget.normalized * Speed.Value * Time.deltaTime;
        
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

