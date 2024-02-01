using UnityEngine;
using Oculus;

public class PlayVibration : MonoBehaviour
{
    public float vibrationDuration = 0.1f;
    public float vibrationIntensity = 0.5f;
    public string tagToCheck; // �±� �̸��� ������ ����

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == tagToCheck)
        {
            // Oculus ��Ʈ�ѷ��� ���� ȿ�� �߰�
            OVRInput.SetControllerVibration(vibrationIntensity, vibrationDuration, OVRInput.Controller.RTouch);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // �浹�� ������ �� ���� ����
        if (collision.gameObject.tag == tagToCheck)
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
    }
}