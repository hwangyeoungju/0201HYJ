using UnityEngine;

public class FaceCameraFront : MonoBehaviour
{
    void Update()
    {
        // 카메라를 향해 UI 요소를 회전시킵니다.
        transform.LookAt(Camera.main.transform.position, Vector3.up);

        // 이제 y축을 기준으로 90도 회전합니다.
        transform.Rotate(0, 90, 0);
    }
}
