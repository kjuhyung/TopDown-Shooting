using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;

    public static ProjectileManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackData attackData)
    {
        //TODO
    }

}
