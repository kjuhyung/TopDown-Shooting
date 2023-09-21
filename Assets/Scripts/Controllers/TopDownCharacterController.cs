using System;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    // event - �ܺο����� ȣ������ ���ϰ� ���´�.
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    protected CharacterStatsHandler Stats { get; private set; }

    // ��ӹ��� Ŭ�������� Awake,Update �ٸ��� ���� ���� virtual ���
    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatsHandler>();
    }

    
    protected virtual void Update()
    {
        HandleAttackDelay();
    }
    

    private void HandleAttackDelay()
    {

        if (Stats.CurrentStats.attackSO == null)
            return;
       if (_timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay) 
       {
            _timeSinceLastAttack += Time.deltaTime;
       }
       if(IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
       {
            _timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.attackSO);
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

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
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
