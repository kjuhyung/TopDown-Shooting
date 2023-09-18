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
        // �̺�Ʈ ����
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }
    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // ��ũź��Ʈ ���ϱ� , ����
        // 0 ~ 3.14 ���� �� * ��׸��� = 0 ������ 360�� Euler ������ ����

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = armRenderer.flipY;
        // z���� 90 �̻��̸� Y�� ������
        // �� �������ų� �� �������ٴ� bool ������ ĳ���͵� ������
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        // ���� Euler ������ armPivot �� z�� ���� = ȸ��
    }
}
