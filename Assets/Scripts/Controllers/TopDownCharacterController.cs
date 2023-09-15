using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        // 1. 트랜스폼을 변경해서 움직이기
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y) * speed * Time.deltaTime;
    }
}
