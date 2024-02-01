using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutController : MonoBehaviour
{
    public GameObject basketPanel; // 장바구니 패널 오브젝트

    // 장바구니 패널의 레이아웃을 갱신하는 메서드
    public void UpdateBasketLayout()
    {
        // GridLayoutGroup 컴포넌트를 찾아서 갱신 요청
        GridLayoutGroup grid = basketPanel.GetComponent<GridLayoutGroup>();
        if (grid != null)
        {
            grid.enabled = false;
            grid.enabled = true; // 이 방식은 GridLayoutGroup을 리셋하여 레이아웃을 갱신합니다.
        }
    }
}
