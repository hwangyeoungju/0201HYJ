using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectX : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // X���� �߽����� ȸ��
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}