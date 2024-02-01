using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class MainMenu1 : MonoBehaviour
{
    public GameObject MainMenuPanel;
    private bool activeMainMenu = false; // 메인 메뉴의 활성화 상태를 추적하는 변수

    void Update()
    {
        // Oculus Quest 컨트롤러의 입력을 확인
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            activeMainMenu = !activeMainMenu; // 메인 메뉴 상태 토글
            MainMenuPanel.SetActive(activeMainMenu); // 메인 메뉴 패널 활성화/비활성화
        }
    }
}
