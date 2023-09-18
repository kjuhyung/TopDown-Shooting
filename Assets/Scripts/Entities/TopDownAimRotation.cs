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
        _controller.OnLookEvent += OnAim;
        // 이벤트 구독
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }
    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // 아크탄젠트 구하기 , 각도
        // 0 ~ 3.14 라디안 값 * 디그리값 = 0 도부터 360도 Euler 값으로 만듬

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = armRenderer.flipY;
        // z값이 90 이상이면 Y를 뒤집기
        // 그 뒤집히거나 안 뒤집혔다는 bool 값으로 캐릭터도 뒤집기
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        // 구한 Euler 값으로 armPivot 의 z값 변경 = 회전
    }
}
