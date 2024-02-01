using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR; // Oculus VR의 OVRInput을 사용하기 위해 추가
using UnityEngine.XR;

public class UICanvasToggle : MonoBehaviour
{
    public Canvas uiCanvas; // UI 캔버스를 참조하기 위한 변수

    void Update()
    {
        // Oculus Quest 오른쪽 컨트롤러의 A 버튼 입력을 확인
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            // UI 캔버스의 활성화/비활성화 상태를 토글
            uiCanvas.enabled = !uiCanvas.enabled;
        }
    }
}