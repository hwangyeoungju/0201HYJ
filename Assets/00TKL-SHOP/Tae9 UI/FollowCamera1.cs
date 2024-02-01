/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform vrCamera;
    public float distanceFromCamera = 2.0f;
    public float heightOffset = 0.5f; // 높이 조정을 위한 변수

    void Update()
    {
        // UI Canvas를 카메라 정면과 높이 조정을 더해서 위치시킵니다.
        transform.position = vrCamera.position + vrCamera.forward * distanceFromCamera + Vector3.up * heightOffset;

        // UI Canvas가 항상 카메라를 정면으로 바라보게 합니다.
        transform.LookAt(vrCamera.position);

        // 높이에 대한 회전만 수정합니다.
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, vrCamera.eulerAngles.y, 0.0f));
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera1 : MonoBehaviour
{
    public Transform vrCamera;
    public float distanceFromCamera = 2.0f;
    public float heightOffset = 0.5f; // 높이 조정을 위한 변수
    public float horizontalOffset = 0.0f; // 좌우 위치 조정을 위한 변수

    void Update()
    {
        // UI Canvas를 카메라 정면, 높이, 그리고 좌우 위치 조정을 더해서 위치시킵니다.
        transform.position = vrCamera.position + vrCamera.forward * distanceFromCamera
                            + Vector3.up * heightOffset + vrCamera.right * horizontalOffset;

        // UI Canvas가 항상 카메라를 정면으로 바라보게 합니다.
        transform.LookAt(vrCamera.position);

        // 높이와 좌우 위치에 대한 회전만 수정합니다.
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, vrCamera.eulerAngles.y, 0.0f));
    }
}