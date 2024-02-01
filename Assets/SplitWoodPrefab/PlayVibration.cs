using UnityEngine;
using Oculus;

public class PlayVibration : MonoBehaviour
{
    public float vibrationDuration = 0.1f;
    public float vibrationIntensity = 0.5f;
    public string tagToCheck; // 태그 이름을 가져올 변수

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == tagToCheck)
        {
            // Oculus 컨트롤러에 진동 효과 추가
            OVRInput.SetControllerVibration(vibrationIntensity, vibrationDuration, OVRInput.Controller.RTouch);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 충돌이 끝났을 때 진동 중지
        if (collision.gameObject.tag == tagToCheck)
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
    }
}