using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Behavior;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private InputActionReference _damageInput;
    [SerializeField] private float _health = 5;
    private BehaviorGraphAgent _graphAgent;

    private void Awake()
    {
        _graphAgent = GetComponent<BehaviorGraphAgent>();
    }

    private void Start()
    {
        _graphAgent.SetVariableValue("Health", _health);
    }

    private void OnEnable()
    {
        _damageInput.action.Enable();
        _damageInput.action.performed += OnDamage;
    }

    private void OnDamage(InputAction.CallbackContext ctx)
    {
        _health -= 1;
        _graphAgent.SetVariableValue("Health", _health);
    }
}
