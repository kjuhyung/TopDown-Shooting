using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownCharacterController _controller;


    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        // 이벤트 구독
        _controller.OnLookEvent += OnAim;
        
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }
    private void RotateArm(Vector2 direction)
    {
        // 아크탄젠트 구하기 , 각도
        // 아크탄젠트 값 = 0 ~ 3.14 라디안 값
        // 곱하기 Rad2Deg = 0도부터 360도 Euler 값으로 만듬
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // z값이 90 이상이면 Y를 뒤집기
        // flipY bool 값으로 캐릭터도 뒤집기
        // 구한 Euler 값으로 armPivot 의 z값 변경 = 회전

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = armRenderer.flipY;        
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        
    }
}
