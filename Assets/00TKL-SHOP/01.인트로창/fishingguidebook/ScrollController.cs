using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public ScrollRect scrollRect;

    void Start()
    {
        // 스크롤바를 최하단으로 설정
        scrollRect.verticalNormalizedPosition = 0f;
    }
}