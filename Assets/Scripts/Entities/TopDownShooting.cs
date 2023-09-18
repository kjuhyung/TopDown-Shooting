using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject testPrefab;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        // 이벤트 구독
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        // 방향 받기
        _aimDirection = newAimDirection;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        // Test Code 화살 생성
        Instantiate(testPrefab, projectileSpawnPosition.position,Quaternion.identity);       
    }
}
