using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    // Ŭ����(ž�ٿ�ĳ������Ʈ�ѷ�) �� ����ϱ� ���� ���� ����
    private TopDownCharacterController _controller; 


    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject testPrefab;

    private void Awake()
    {
        _controller= GetComponent<TopDownCharacterController>();
    }
    void Start()
    {
        _controller.OnAttackEvent += Onshoot;
        _controller.OnLookEvent += OnAim;
    }
    private void OnAim (Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }

    private void Onshoot()
    {
        CreateProjectile();
    }
    private void CreateProjectile()
    {
        Instantiate(testPrefab, projectileSpawnPosition.position,Quaternion.identity);
    }


    private void Update()
    {
        
    }
}
