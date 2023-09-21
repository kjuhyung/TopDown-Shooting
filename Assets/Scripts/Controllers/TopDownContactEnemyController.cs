using System;
using UnityEngine;

public class TopDownContactEnemyController : TopDownEnemyController
{
    [SerializeField] [Range(0f, 100f)] private float followRange;
    [SerializeField] private string targetTag = "Player";
    private bool _isCollidingWithTarget;

    [SerializeField] private SpriteRenderer characterRenderer;

    private HealthSystem healthSystem;
    private HealthSystem _collidingTagetHealthSystem;
    private TopDownMovement _collidingMovement;

    protected override void Start()
    {
        base.Start();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDamage += OnDamage;
    }

    private void OnDamage()
    {
        followRange = 100f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if(_isCollidingWithTarget)
        {
            ApplyHealthChange();
        }

        Vector2 direction = Vector2.zero;
        if(DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject receiver = collision.gameObject;

        if(!receiver.CompareTag(targetTag))
        {
            return;
        }
        _collidingTagetHealthSystem = receiver.GetComponent<HealthSystem>();
        if (_collidingTagetHealthSystem != null )
        {
            _isCollidingWithTarget = true;
        }

        _collidingMovement = receiver.GetComponent<TopDownMovement>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag(targetTag))
        {
            return;
        }

        _isCollidingWithTarget = false;
    }

    private void ApplyHealthChange()
    {
        AttackSO attackSO = Stats.CurrentStats.attackSO;
        bool hasBeenChanged = _collidingTagetHealthSystem.ChangeHealth(-attackSO.power);
        if(attackSO.isOnKnockback && _collidingMovement != null )
        {
            _collidingMovement.ApplyKnockback(transform, attackSO.knockbackPower,attackSO.knockbackTime);
        }
    }
}
