using UnityEngine;

public class FaceCameraFront : MonoBehaviour
{
    void Update()
    {
        // ī�޶� ���� UI ��Ҹ� ȸ����ŵ�ϴ�.
        transform.LookAt(Camera.main.transform.position, Vector3.up);

        // ���� y���� �������� 90�� ȸ���մϴ�.
        transform.Rotate(0, 90, 0);
    }
}
