using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public ScrollRect scrollRect;

    void Start()
    {
        // ��ũ�ѹٸ� ���ϴ����� ����
        scrollRect.verticalNormalizedPosition = 0f;
    }
}