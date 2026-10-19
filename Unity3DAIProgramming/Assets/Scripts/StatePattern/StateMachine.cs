using System;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // current null인 상황 = 맨 처음 구동할 때
    private StateBase _current;
    private IStateEvent _stateEvent;
    
    
    private void Awake()
    {
        // 무슨 상태던 누구의 상태던 상관 없이 상태 처리 해줌 
        _stateEvent = GetComponent<IStateEvent>();
    }

    private void OnEnable()
    {
        _stateEvent.OnStateChange += ChangeState;
    }
    
    public void Update()
    {
        // 상태 null일 수 있기에
        _current?.Update();
    }

    private void OnDisable()
    {
        _stateEvent.OnStateChange -= ChangeState;
    }

    public void ChangeState(StateBase state)
    {
        // 다음 3가지 대비할 필요 있음
        // state == null ???
        // _current == state ???
        // _current == null ???

        if (state == null || _current == state) return;
        
        // 이전 상태의 Exit(), current가 null인지 체크 : 최초 상태에 호출 안되게
        _current?.Exit();
        // 현재 상태 변경
        _current = state;
        // 현재 상태의 Enter()
        _current.Enter();
    }
}
