using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어 전용 상태 객체
/// </summary>
public sealed class IdleState : StateBase
{
    // public IdleState(PlayerController controller) : base(controller)
    // {
    //     
    // }
    private PlayerController _controller;

    public IdleState(PlayerController controller)
    {
        _controller = controller;
    }
    
    public override void Enter()
    {
        Debug.Log("<color=blue>Idle 상태 진입</color>");
        _controller.AttackInputRef.action.performed += TransitionAttack;
    }

    public override void Update()
    {
        // 공격 메서드는 제외 TODO
        Debug.Log("<color=blue>Idle 상태</color>");
    }

    public override void Exit()
    {
        Debug.Log("<color=blue>Idle 상태 빠져나감</color>");
        _controller.AttackInputRef.action.performed -= TransitionAttack;
    }

    private void TransitionAttack(InputAction.CallbackContext ctx)
    {
        _controller.SetState(_controller.Attack);
    }
}
