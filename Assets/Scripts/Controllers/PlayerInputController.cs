using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
        
    protected override void Awake()
    {
        base.Awake(); // �θ� Ŭ������ Awake�� ���� ����
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        // Debug.Log("OnMove" + value.ToString());
        // �Է°��� moveInput �� �Ҵ��ؼ� CallMoveEvent ����

        Vector2 moveInput = value.Get<Vector2>().normalized;       
        CallMoveEvent(moveInput);
    }
    public void OnLook(InputValue value)
    {
        // Debug.Log("OnLook" + value.ToString());
        // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ - ���콺 ��ġ
        // ���콺 ��ġ���� �� ��ġ�� ���� - ���� ���콺�� �ٶ󺸴� ����

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
        // ���콺 ���� ��ư�� ������ True, �ƴϸ� false
        IsAttacking = value.isPressed;
    }
}
