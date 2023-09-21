using UnityEngine;

public class TopDownEnemyController : TopDownCharacterController
{
    GameManager gameManager;
    protected Transform ClosestTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        gameManager = GameManager.instance;
        ClosestTarget = gameManager.Player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }  // Ÿ�ٰ� �ڽ� ������ �Ÿ� 
    
    protected Vector2 DirectionToTarget()
    {
        return (ClosestTarget.position - transform.position).normalized;
    } // Ÿ�ٰ� �ڽ� ������ ����
}
