using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Check Hp", story: "If [Hp] <= 0", category: "Conditions", id: "dfd35c240b8f263a13e95072049c5c88")]
public partial class CheckHpCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> Hp;

    public override bool IsTrue()
    {
        return true;
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
