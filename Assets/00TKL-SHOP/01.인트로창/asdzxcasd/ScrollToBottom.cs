using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollToBottom : MonoBehaviour
{
    public ScrollRect scrollRect;

    void Start()
    {
        // ��ũ�� �並 �� �Ʒ��� �̵���ŵ�ϴ�.
        scrollRect.verticalNormalizedPosition = 0;
    }
}