using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    // event - 외부에서는 호출하지 못하게 막는다.

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
        // null 이 아닐 때만 실행
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

}


    // {
    //// 기본적인 이동 연습 코드
    // [SerializeField] private float speed = 5f;
    // void Update()
    // {
    //    // 트랜스폼을 변경해서 움직이기
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float y = Input.GetAxisRaw("Vertical");

    //    transform.position += new Vector3(x, y) * speed * Time.deltaTime;
    // }
    // }
