using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectX : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // X축을 중심으로 회전
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}