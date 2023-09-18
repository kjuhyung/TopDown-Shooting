using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        // Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;       
        CallMoveEvent(moveInput);
        // 입력값을 moveInput 에 할당해서 CallMoveEvent 실행
    }
    public void OnLook(InputValue value)
    { 
        // Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        // 스크린 좌표를 월드 좌표로 변환 - 마우스 위치
        newAim = (worldPos - (Vector2)transform.position).normalized;
        // 마우스 위치에서 내 위치를 빼기 - 내가 마우스를 바라보는 방향

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }      
    }
    public void OnFire(InputValue value)
    {

        Debug.Log("OnFire" + value.ToString());
    }
}
