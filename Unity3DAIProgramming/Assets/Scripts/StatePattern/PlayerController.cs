using UnityEngine;
using UnityEngine.InputSystem;
using System;

// 플레이어 컨트롤러 추가하면 자동으로 StateMachine 컴포넌트 추가
[RequireComponent(typeof(StateMachine))]
public class PlayerController : MonoBehaviour, IStateEvent, IDamageable
{
    [SerializeField] private InputActionReference _attackInput;
    [SerializeField] private InputActionReference _damageInput;
    
    // private StateMachine _stateMachine = new();

    private StateBase _idle;
    private StateBase _attack;
    private StateBase _dead;
    
    public Action<StateBase> OnStateChange { get; set; } // 인터페이스 상속 필수 프로퍼티
    
    public InputActionReference AttackInputRef => _attackInput;
    public StateBase Idle => _idle;
    public StateBase Attack => _attack;
    
    private void Awake()
    {
        // 상태 객체 생성
        _idle = new IdleState(this);
        _attack = new AttackState(this);
        _dead = new DeadState(this);
    }
    
    private void OnEnable()
    {
        _attackInput.action.Enable();
        _damageInput.action.Enable();
        _damageInput.action.performed += OnDamageInput;
    }
    
    private void Start()
    {
        OnStateChange?.Invoke(_idle);
    }

    
    // disable에서 해제 안해주면 생기는 일이 뭔지?
    private void OnDisable()
    {
        _attackInput.action.Disable();
        _damageInput.action.Disable();
        _damageInput.action.performed -= OnDamageInput;
    }

    public void SetState(StateBase state)
    {
        OnStateChange?.Invoke(state);
    }

    private void OnDamageInput(InputAction.CallbackContext ctx)
    {
        TakeDamage(1);
    }

    public void TakeDamage(int damage)
    {
        // 체력 감소 TODO
        
        // 체력 0이하면 사망
        OnStateChange?.Invoke(_dead);
    }
}
