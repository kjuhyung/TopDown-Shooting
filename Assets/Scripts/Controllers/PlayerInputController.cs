using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
        
    protected override void Awake()
    {
        base.Awake(); // 부모 클래스의 Awake를 먼저 실행
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        // Debug.Log("OnMove" + value.ToString());
        // 입력값을 moveInput 에 할당해서 CallMoveEvent 실행

        Vector2 moveInput = value.Get<Vector2>().normalized;       
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        // Debug.Log("OnLook" + value.ToString());
        // 스크린 좌표를 월드 좌표로 변환 - 마우스 위치
        // 마우스 위치에서 내 위치를 빼기 - 내가 마우스를 바라보는 방향

        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);        
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }      
    }
    public void OnFire(InputValue value)
    {
        // 마우스 좌측 버튼을 누르면 True, 아니면 false
        IsAttacking = value.isPressed;
    }
}
