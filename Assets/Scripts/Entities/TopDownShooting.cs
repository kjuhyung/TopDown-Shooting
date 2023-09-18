
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private ProjectileManager _projectileManager;
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        _projectileManager = ProjectileManager.instance;
        // �̺�Ʈ ����
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        // ���� �ޱ�
        _aimDirection = newAimDirection;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberOfProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;
        // ��ä�÷� �߻��ϱ�

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            // ȭ�� ���̻����� ��
            float angle = minAngle + projectilesAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            CreateProjectile(rangedAttackData, angle);
        }       
    }

    private void CreateProjectile(RangedAttackData rangedAttackData, float angle)
    {
        _projectileManager.ShootBullet(
            projectileSpawnPosition.position,
            RotateVector2(_aimDirection,angle),
            rangedAttackData);
        // �߻���ġ, ȸ����, ���ݵ�����
    } 
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        // ����(v)�� ���ʹϾ�(����)��ŭ ȸ����Ų��.
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
