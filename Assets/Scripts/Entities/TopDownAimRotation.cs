using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer chracterRenderer;

    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }
    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        chracterRenderer.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }

}
