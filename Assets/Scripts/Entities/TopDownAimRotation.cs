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
        // �̺�Ʈ ����
        _controller.OnLookEvent += OnAim;
        
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }
    private void RotateArm(Vector2 direction)
    {
        // ��ũź��Ʈ ���ϱ� , ����
        // ��ũź��Ʈ �� = 0 ~ 3.14 ���� ��
        // ���ϱ� Rad2Deg = 0������ 360�� Euler ������ ����
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // z���� 90 �̻��̸� Y�� ������
        // flipY bool ������ ĳ���͵� ������
        // ���� Euler ������ armPivot �� z�� ���� = ȸ��

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = armRenderer.flipY;        
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        
    }
}
