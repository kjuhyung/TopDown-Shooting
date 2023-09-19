using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private RangedAttackData _attackData;
    private float _cureentDuration;
    private Vector2 _direction;
    private bool _isReady;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;
    private ProjectileManager _projectileManager;

    public bool fxOnDestroy = true;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }
    private void Update()
    {
        if (!_isReady)
        {
            return;
        }

        _cureentDuration = Time.deltaTime;

        if (_cureentDuration > _attackData.duration)
        {
            DestroyProjectile(transform.position, false);
        }
        // �������� �෹�̼Ǻ��� ���� �෹�̼��� ũ�� ����

        _rigidbody.velocity = _direction * _attackData.speed;
        // �̵� ó��
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - _direction * .2f, fxOnDestroy);
        }
    }

    public void InitializeAttack(Vector2 direction, RangedAttackData attackData, ProjectileManager projectileManager)
    {
        // �ʱ�ȭ 
        _projectileManager = projectileManager;
        _attackData = attackData;
        _direction = direction;

        UpdateProjectileSprite();
        _trailRenderer.Clear();
        _cureentDuration = 0;
        _spriteRenderer.color = attackData.projectileColor;

        transform.right = _direction;
        
        _isReady = true;
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _attackData.size;
    }
    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        // ���� ó��
        if(createFx)
        {

        }
        gameObject.SetActive(false);
    }
}
