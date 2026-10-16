using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// 플레이어 전용 상태 객체
/// </summary>
public sealed class AttackState : StateBase
{
    // public IdleState(PlayerController controller) : base(controller)
    // {
    //     
    // }
    private PlayerController _controller;

    public AttackState(PlayerController controller)
    {
        _controller = controller;
    }
    public override void Enter()
    {
        Debug.Log("<color=green>Attack 상태 진입</color>");
    }

    public override void Update()
    {
        // 공격 메서드는 제외 TODO
        Debug.Log("<color=green>Attack 상태</color>");
        _controller.SetState(_controller.Idle);
    }

    public override void Exit()
    {
        Debug.Log("<color=green>Attack 상태 빠져나감</color>");

    }
}
