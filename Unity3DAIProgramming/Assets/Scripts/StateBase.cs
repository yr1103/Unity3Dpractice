using UnityEngine;

// 추상 클래스와 인터페이스의 차이 복습하기
public abstract class StateBase
{
    // protected PlayerController _controller;
    //
    // public StateBase(PlayerController controller)
    // {
    //     _controller = controller;
    // }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

