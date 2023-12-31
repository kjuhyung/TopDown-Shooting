using UnityEngine;

[CreateAssetMenu(fileName ="DefaultAttackData", menuName = "TopDownController/Attack/Default",order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("# Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;
    // 공격 크기, 딜레이, 파워, 속도, 목표 설정

    [Header("# Knock Back Info")]
    public bool isOnKnockback;
    public float knockbackPower;
    public float knockbackTime;    
}

