using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // event - 외부에서는 호출하지 못하게 막는다.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    // 상속받은 클래스에서 Update 를 다르게 쓰기 위해 virtual 사용
    protected virtual void Update()
    {
        HandleAttackDelay();
    }
    

    private void HandleAttackDelay()
    {
       if (_timeSinceLastAttack <= 0.2f) // TODO
       {
            _timeSinceLastAttack += Time.deltaTime;
       }
       if(IsAttacking && _timeSinceLastAttack > 0.2f)
       {
            _timeSinceLastAttack = 0;
            CallAttackEvent();
       }            
    }

    public void CallMoveEvent(Vector2 direction)
    {
        // null 이 아닐 때만 실행
        OnMoveEvent?.Invoke(direction);
        
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
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
