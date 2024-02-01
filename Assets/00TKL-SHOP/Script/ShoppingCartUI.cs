using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class ShoppingCartUI : MonoBehaviour
{
    public GameObject ShoppingCartPanel;
    private bool activeShoppingCart = false; // 쇼핑 카트 UI의 활성화 상태를 추적하는 변수
    void Start()
    {
        // 게임 시작 시 쇼핑 카트 패널을 비활성화
        ShoppingCartPanel.SetActive(false);
    }

    void Update()
    {
        // Oculus Quest 오른쪽 컨트롤러의 A 버튼 입력을 확인
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            activeShoppingCart = !activeShoppingCart; // 쇼핑 카트 UI 상태 토글
            ShoppingCartPanel.SetActive(activeShoppingCart); // 쇼핑 카트 패널 활성화/비활성화
        }
    }
}




