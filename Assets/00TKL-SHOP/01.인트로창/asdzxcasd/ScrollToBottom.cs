using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollToBottom : MonoBehaviour
{
    public ScrollRect scrollRect;

    void Start()
    {
        // 스크롤 뷰를 맨 아래로 이동시킵니다.
        scrollRect.verticalNormalizedPosition = 0;
    }
}