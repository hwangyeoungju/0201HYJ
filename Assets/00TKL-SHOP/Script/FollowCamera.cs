using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FollowCamera : MonoBehaviour
{
    public Transform vrCamera;
    public float distanceFromCamera = 2.0f;
    public float heightOffset = 0.5f; // ���� ������ ���� ����

    void Update()
    {
        // UI Canvas�� ī�޶� ����� ���� ������ ���ؼ� ��ġ��ŵ�ϴ�.
        transform.position = vrCamera.position + vrCamera.forward * distanceFromCamera + Vector3.up * heightOffset;

        // UI Canvas�� �׻� ī�޶� �������� �ٶ󺸰� �մϴ�.
        transform.LookAt(vrCamera.position);

        // ���̿� ���� ȸ���� �����մϴ�.
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, vrCamera.eulerAngles.y, 0.0f));
    }
}