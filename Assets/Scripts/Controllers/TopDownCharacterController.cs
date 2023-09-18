using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // event - �ܺο����� ȣ������ ���ϰ� ���´�.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }

    // ��ӹ��� Ŭ�������� Update �� �ٸ��� ���� ���� virtual ���
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
        // null �� �ƴ� ���� ����
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
