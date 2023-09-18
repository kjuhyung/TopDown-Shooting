using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    // event - �ܺο����� ȣ������ ���ϰ� ���´�.

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
        // null �� �ƴ� ���� ����
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

}


    // {
    //// �⺻���� �̵� ���� �ڵ�
    // [SerializeField] private float speed = 5f;
    // void Update()
    // {
    //    // Ʈ�������� �����ؼ� �����̱�
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float y = Input.GetAxisRaw("Vertical");

    //    transform.position += new Vector3(x, y) * speed * Time.deltaTime;
    // }
    // }
