using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private ProjectileManager _projectileManager;
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public AudioClip shootingClip;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        _projectileManager = ProjectileManager.instance;
        // 이벤트 구독
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 newAimDirection)
    {
        // 방향 받기
        _aimDirection = newAimDirection;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        // AttackSO 형식을 RanagedAttackData 형식으로 형변환
        float projectilesAngleSpace = rangedAttackData.multipleProjectilesAngel;
        int numberOfProjectilesPerShot = rangedAttackData.numberOfProjectilesPerShot;
        // 발사각도, 발사개수 들어온 정보로 변수에 할당하기
        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackData.multipleProjectilesAngel;
        // 부채꼴로 발사하기 위한 변수 , 최소각도

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            // 화살 사이사이의 각
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
        // 발사위치, 회전각, 공격데이터
        if (shootingClip)
            SoundManager.PlayClip(shootingClip);
    } 
    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        // 벡터(v)를 쿼터니언(각도)만큼 회전시킨다.
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
