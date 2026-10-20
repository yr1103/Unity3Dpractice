// using System;
// using UnityEngine;
// using UnityEngine.AI;
// using UnityEngine.InputSystem;
//
// public class PlayerMovement : MonoBehaviour
// {
//
//     
//     // NavMesh 없이
//     // 마우스 클릭 -> 클릭한 곳 좌표 받아서 이동하기(Ground 위에서만)
//
//     [SerializeField] private LayerMask _groundLayer;
//     [SerializeField] private InputActionReference _mouseLeftInput;
//     [SerializeField] private InputActionReference _mousePosition;
//     [SerializeField] private Transform _targetTransform;
//     
//     private Camera _camera;
//     
//     private void Awake()
//     {
//         //CacheComponents();
//         _camera = Camera.main;
//     }
//
//     private void OnEnable() => BindInputEvents();
//     
//     // 레이캐스트랑 레이어마스크
//
//     private void BindInputEvents()
//     {
//         _mouseLeftInput.action.Enable();
//         _mousePosition.action.Enable();
//         _mouseLeftInput.action.performed += OnMouseLeftButtonDown;
//     }
//
//     private void Start()
//     {
//         _targetTransform.position = transform.position;
//     }
//     private void Update()
//     {
//         // 기존 방식
//         //transform.Translate(transform.forward * 3 * 
//         MovetoTarget();
//     }
//     
//     private void OnMouseLeftButtonDown(InputAction.CallbackContext context)
//     {
//         ClicktoMove();
//     }
//     
//
//     
//     private void ClicktoMove()
//     {
//         Vector2 screen = _mousePosition.action.ReadValue<Vector2>();
//         Ray ray = _camera.ScreenPointToRay(screen);
//
//         if (Physics.Raycast(ray, out RaycastHit hit, _groundLayer))
//         {
//              _targetTransform.position = hit.point;
//         }
//     }
//
//     private void MovetoTarget()
//     {
//         transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, Time.deltaTime * 10);
//     }
//
// }

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // NavMesh 생각하지 말고

    // 마우스 클릭 -> 클릭한 곳의 좌표 받아서 이동하기(Ground 위에서만)
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private InputActionReference _mouseLeftInput;
    [SerializeField] private InputActionReference _mousePosition;
    [SerializeField] private Transform _goalTransform;

    private Camera _cam;

    private void Awake() => CacheComponents();
    private void OnEnable() => BindInputEvents();
    private void Start() => Init();
    private void Update() => MoveToGoal();

    private void CacheComponents()
    {
        _cam = Camera.main;
    }

    private void BindInputEvents()
    {
        _mouseLeftInput.action.Enable();
        _mousePosition.action.Enable();
        _mouseLeftInput.action.performed += OnMouseLeftButtonDown;
    }

    private void OnMouseLeftButtonDown(InputAction.CallbackContext context)
    {
        SetGoalPosition();
    }

    private void Init()
    {
        _goalTransform.position = transform.position;
    }

    private void SetGoalPosition()
    {
        Vector2 screen = _mousePosition.action.ReadValue<Vector2>();
        Ray ray = _cam.ScreenPointToRay(screen);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _groundLayer))
        {
            _goalTransform.position = hit.point;
        }
    }

    private void MoveToGoal()
    {
        transform.position = Vector3.MoveTowards(transform.position, _goalTransform.position, 3 * Time.deltaTime);
    }
}